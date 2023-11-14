using HE160735_NguyenMinhTan_Project.CallAPI;
using HE160735_NguyenMinhTan_Project.Models;
using HE160735_NguyenMinhTan_Project_API.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;

namespace HE160735_NguyenMinhTan_Project.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly string Baseurl = "";
        private readonly IHttpContextAccessor _session;
        List<Book> books = new List<Book>();
        List<Food> foods = new List<Food>();
        List<User> users = new List<User>();
        List<Category> categories = new List<Category>();
        UserAPICalling userAPICalling = new UserAPICalling();
        BookAPICalling bookAPICalling = new BookAPICalling();
        FoodAPICalling foodAPICalling = new FoodAPICalling();
        CategoryAPICalling categoryAPICalling = new CategoryAPICalling();

        public DashboardController(IHttpContextAccessor httpContextAccessor, IConfiguration iConfig)
        {
            _session = httpContextAccessor;
            configuration = iConfig;
            Baseurl = configuration.GetValue<string>("Authentication:Url:BaseUrlAPI");
        }

        public async Task<IActionResult> Index()
        {
            books = await bookAPICalling.GetBooks();
            ViewData["Books"] = books;
            return View();
        }

        public async Task<IActionResult> User()
        {
            users = await userAPICalling.GetUsers();
            ViewData["Users"] = users;
            return View();
        }

        public async Task<IActionResult> Product()
        {
            foods = await foodAPICalling.GetFoods();
            categories = await categoryAPICalling.GetCategories();
            ViewData["Foods"] = foods;
            ViewData["Categories"] = categories;
            return View();
        }

        public async Task<IActionResult> BookDelete(int bookid)
        {
            await bookAPICalling.DeleteBook(bookid);
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> ProductDelete(int foodid)
        {
            await foodAPICalling.DeleteFood(foodid);
            return RedirectToAction("Product", "Dashboard");
        }

        public async Task<IActionResult> UserDelete(int userid)
        {
            await userAPICalling.DeleteUser(userid);
            return RedirectToAction("User", "Dashboard");
        }

        public async Task<IActionResult> BookFilter(string name, string phone, string bookdate, string booktime)
        {
            List<Book> books = await bookAPICalling.FilterBook(name, phone, bookdate, booktime);
            ViewData["Books"] = books;
            return View("Index", "Dashboard");
        }

        public async Task<IActionResult> UserFilter(string username, string phone, string role, string Email)
        {
            List<User> users = await userAPICalling.FilterUser(username, phone, role, Email);
            ViewData["Users"] = users;
            return View("User", "Dashboard");
        }

        public async Task<IActionResult> Foodilter(string foodname, string foodprice, string category, string fooddescription, string foodpricefrom, string foodpriceto)
        {
            List<Food> foods = await foodAPICalling.FilterFood(foodname, foodprice, category, fooddescription, foodpricefrom, foodpriceto);
            categories = await categoryAPICalling.GetCategories();
            ViewData["Foods"] = foods;
            ViewData["Categories"] = categories;
            return View("Product", "Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> ProductEdit(int foodid)
        {
            Food food = await foodAPICalling.GetFoodById(foodid);
            categories = await categoryAPICalling.GetCategories();
            ViewData["Food"] = food;
            ViewData["Categories"] = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(string foodId, string foodName, string foodDes, string foodPrice, string category, string foodUrl)
        {
            if (Int32.Parse(foodPrice) < 0)
            {
                ViewData["message"] = "Price can not lower 0!!";
                categories = await categoryAPICalling.GetCategories();
                ViewData["Food"] = await foodAPICalling.GetFoodById(int.Parse(foodId));
                ViewData["Categories"] = categories;
                return View();
            }
            FoodDTO food = new FoodDTO()
            {
                FoodId = int.Parse(foodId),
                FoodName = foodName,
                FoodDescription = foodDes,
                FoodPrice = Double.Parse(foodPrice),
                FoodCategory = int.Parse(category),
                FoodImage = foodUrl
            }; 
            await foodAPICalling.UpdateFood(food);
            foods = await foodAPICalling.GetFoods();
            categories = await categoryAPICalling.GetCategories();
            ViewData["Foods"] = foods;
            ViewData["Categories"] = categories;
            return View("Product", "Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> UserBan(int userid)
        {
            await userAPICalling.UpdateUserRole(0, userid);
            List<User> users = await userAPICalling.GetUsers();
            ViewData["Users"] = users;
            return View("User", "Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> UserUnBan(int userid)
        {
            await userAPICalling.UpdateUserRole(1, userid);
            List<User> users = await userAPICalling.GetUsers();
            ViewData["Users"] = users;
            return View("User", "Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> Category()
        {
            List<Category> categories = await categoryAPICalling.GetCategories();
            ViewData["Categories"] = categories;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CategoryEdit(int cateid)
        {
            Category category = await categoryAPICalling.GetCategoryById(cateid);
            ViewData["Category"] = category;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryEdit(string cateid, string catename)
        {
            if (string.IsNullOrEmpty(cateid) || string.IsNullOrEmpty(catename))
            {
                Category category = await categoryAPICalling.GetCategoryById(int.Parse(cateid));
                ViewData["Category"] = category;
                ViewData["message"] = "Please Fill All Blank!!";
                return View();
            }
            else
            {
                await categoryAPICalling.UpdateCategory(cateid, catename);
                List<Category> categories = await categoryAPICalling.GetCategories();
                ViewData["Categories"] = categories;
                return View("Category", "Dashboard");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CategoryDelete(string cateid)
        {
            List<Food> foods = await foodAPICalling.GetFoodsByCateId(cateid);
            if (foods.Count() > 1)
            {
                List<Category> categories = await categoryAPICalling.GetCategories();
                ViewData["Categories"] = categories;
                ViewData["message"] = "Can't not delete because relate product!!!!";
                return View("Category", "Dashboard");
            }
            else
            {
                try
                {
                    await categoryAPICalling.DeleteCategory(cateid);
                    ViewData["message"] = "Delete Success";
                }
                catch (Exception ex) 
                {
                    ViewData["message"] = "Delete Fail";
                }
                List<Category> categories = await categoryAPICalling.GetCategories();
                ViewData["Categories"] = categories;
                return View("Category", "Dashboard");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryCreate(string catename)
        {
            if (string.IsNullOrEmpty(catename))
            {
                ViewData["message"] = "Please Fill All Blank!!";
                return View();
            }
            else if (await categoryAPICalling.GetCategoryByCateName(catename) != null)
            {
                ViewData["message"] = "Already Exist this category!!";
                return View();
            }
            else
            {
                try
                {
                    await categoryAPICalling.CreateCategory(catename);
                    ViewData["message"] = "Create Success!!";
                }
                catch (Exception ex)
                {
                    ViewData["message"] = "Create Fail!!";
                }
                List<Category> categories = await categoryAPICalling.GetCategories();
                ViewData["Categories"] = categories;
                return View("Category", "Dashboard");
            }
        }
    }
}
