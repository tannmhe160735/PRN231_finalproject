using HE160735_NguyenMinhTan_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Azure;
using HE160735_NguyenMinhTan_Project.CallAPI;

namespace HE160735_NguyenMinhTan_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly string Baseurl = "";
        private readonly IHttpContextAccessor _session;
        List<Food> foods = new List<Food>();
        UserAPICalling userAPICalling = new UserAPICalling();
        BookAPICalling bookAPICalling = new BookAPICalling();
        FoodAPICalling foodAPICalling = new FoodAPICalling();
        CategoryAPICalling categoryAPICalling = new CategoryAPICalling();

        public HomeController(IHttpContextAccessor httpContextAccessor, IConfiguration iConfig)
        {
            _session = httpContextAccessor;
            configuration = iConfig;
            Baseurl = configuration.GetValue<string>("Authentication:Url:BaseUrlAPI");
        }

        public async Task<IActionResult> Index()
        {
            foods = await foodAPICalling.GetFoods();
            ViewData["Foods"] = foods;
            return View();
        }

        [HttpGet]
        public IActionResult Admin()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            _session.HttpContext.Session.Clear();
            foods = await foodAPICalling.GetFoods();
            ViewData["Foods"] = foods;
            return View("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            User user = await userAPICalling.LoginByUserPass(username, password);
            if (user == null)
            {
                return View();
            }
            else
            {
                _session.HttpContext.Session.SetInt32("User_id", user.UserId);
                if (_session.HttpContext.Session.GetInt32("Guest_id") != null)
                {
                    int guestId = (int)_session.HttpContext.Session.GetInt32("Guest_id");
                    int userId = (int)_session.HttpContext.Session.GetInt32("User_id");
                    await bookAPICalling.ReplaceBookUserId(guestId, userId);
                }
                foods = await foodAPICalling.GetFoods();
                ViewData["Foods"] = foods;
                return View("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password, string repassword)
        {
            User usercheck = await userAPICalling.GetUserByUserName(username);
            if (usercheck.Username != null)
            {
                ViewData["message"] = "User Exist!!";
                return View();
            }
            usercheck = await userAPICalling.GetUserByEmail(email);
            if (usercheck.Email != null)
            {
                ViewData["message"] = "Email used!!";
                return View();
            }
            if (!email.Contains("@"))
            {
                ViewData["message"] = "Email have to contain '@'!!";
                return View();
            }
            if (password == repassword)
            {
                User user = new User();
                user.Username = username;
                user.Email = email;
                user.Password = password;
                user.Phone = "0";
                user.Role = 1;
                ViewData["message"] = await userAPICalling.Register(user); ;
                return View("Login", "Home");
            }
            else
            {
                ViewData["message"] = "Password and RePassword do not match!!";
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string username, string email)
        {
            User acc = await userAPICalling.GetUserByUsernameEmail(username, email);
            if (acc != null)
            {
                try
                {
                    TempData["User"] = username;
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddMinutes(1));
                    HttpContext.Response.Cookies.Append("OTP", await userAPICalling.SendOtp(email), cookieOptions);
                    return RedirectToAction("EnterOTP", "Home");
                }
                catch (Exception)
                {
                    ViewData["Message"] = "Error";
                }
                return View();
            }
            else
            {
                ViewData["Message"] = "Account does not exist!!";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EnterOTP()
        {
            var user = TempData["User"];
            var otp = HttpContext.Request.Cookies["OTP"];
            if (otp != null)
            {
                ViewData["User"] = user;
                ViewData["OTP"] = otp;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EnterOTP(string username, string otpinput, string otpmail)
        {
            if (otpinput == otpmail)
            {
                TempData["User"] = username;
                return RedirectToAction("ChangePassword", "Home");
            }
            else
            {
                ViewData["User"] = username;
                ViewData["OTP"] = otpmail;
                ViewData["Message"] = "Wrong otp";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            ViewData["User"] = TempData["User"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string username, string password, string repassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repassword))
            {
                ViewData["Message"] = "Input Invalid!!";
                ViewData["User"] = username;
                return View();
            }
            else if (!password.Equals(repassword))
            {
                ViewData["Message"] = "Input password and repassword not match!!";
                ViewData["User"] = username;
                return View();
            }
            else
            {
                string message = await userAPICalling.ChangePassword(username, password);
                ViewData["message"] = message;
                return View("Login", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Book(string name, string email, string phone, string date, string people, string message, string time)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(date) || string.IsNullOrEmpty(people) || string.IsNullOrEmpty(time))
            {
                ViewData["message"] = "Please input all";
            }
            User user = new User();
            Book book = new Book();
            if (_session.HttpContext.Session.GetInt32("User_id") != null)
            {
                int id = (int) _session.HttpContext.Session.GetInt32("User_id");
                user = await userAPICalling.GetUserById(id);
                book.UserId = user.UserId;
            }
            else
            {
                Random random = new Random();
                int userId = random.Next(100000, 999999);
                book.UserId = userId;
                _session.HttpContext.Session.SetInt32("Guest_id", userId);
            }
            book.BookDate = DateTime.Parse(date);
            book.BookTime = time;
            book.NumberOfPeople = int.Parse(people);
            book.Note = message;
            book.Name = name;
            book.Email = email;
            book.Phone = phone;
            string mes = await bookAPICalling.AddBook(book);
            ViewData["message"] = mes;
            foods = await foodAPICalling.GetFoods();
            ViewData["Foods"] = foods;
            return View("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> MyBooking()
        {
            if (_session.HttpContext.Session.GetInt32("User_id") == null)
            {
                ViewData["message"] = "Please Login First!!";
                return View("Login", "Home");
            }
            else
            {
                int userId = (int) _session.HttpContext.Session.GetInt32("User_id");
                List<Book> books = await bookAPICalling.GetBookByUserId(userId);
                ViewData["Books"] = books;
                return View();
            }
        }
    }
}

