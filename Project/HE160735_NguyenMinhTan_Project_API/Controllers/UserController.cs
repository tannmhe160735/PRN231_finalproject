using HE160735_NguyenMinhTan_Project_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

namespace HE160735_NguyenMinhTan_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        He160735NguyenMinhTanProjectContext _context;
        private readonly IConfiguration configuration;
        public UserController(He160735NguyenMinhTanProjectContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        [HttpGet]
        public IActionResult getUsers()
        {
            try
            {
                List<User> users = _context.Users.ToList();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Login")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Get-user-by-id")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.UserId == id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Get-user-by-username")]
        public IActionResult GetUserByUsername(string username)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Get-user-by-email")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Get-user-by-username-email")]
        public IActionResult GetUserByUsernameEmail(string username, string email)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Filter-User")]
        public IActionResult getFilterUsers(string? username, string? phone, string? role, string? Email)
        {
            try
            {
                List<User> users = _context.Users.ToList();
                if (!string.IsNullOrEmpty(username))
                {
                    users = users.Where(u => u.Username.Contains(username)).ToList();
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    users = users.Where(b => b.Phone == phone).ToList();
                }
                if (!role.Equals("All"))
                {
                    users = users.Where(b => b.Role == int.Parse(role)).ToList();
                }
                if (!string.IsNullOrEmpty(Email))
                {
                    users = users.Where(b => b.Email.Contains(Email)).ToList();
                }
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Send-otp")]
        public IActionResult SendOTP(string email)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 999999).ToString("D6");
            try
            {
                string emailAu = configuration.GetValue<string>("Authentication:Email:Username");
                string passAu = configuration.GetValue<string>("Authentication:Email:Password");
                var senderEmail = new MailAddress(emailAu, "Admin");
                var receiverEmail = new MailAddress(email, "Receiver");
                var password = passAu;
                var sub = "NEW PASSWORD";
                var body = "Your otp is: " + otp + "\n Thank!!!";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(otp);
        }

        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            try
            {
                
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("Register sucessful");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Change-password")]
        public IActionResult ChangePassword(string username, string password)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.Username == username);
                user.Password = password;
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok("Change password successful");
            }
            catch (Exception e)
            {
                 return BadRequest(e.Message);
            }
        }

        [HttpPut("Update-Role")]
        public IActionResult UpdateRole(int role, int id)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(u => u.UserId == id);
                user.Role = role;
                _context.Users.Update(user);
                _context.SaveChanges();
                if(role == 1)
                {
                    return Ok("Unban successful");
                }
                if(role == 0)
                {
                    return Ok("Ban successful");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete-User")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(b => b.UserId == id);
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok("Delete User Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
