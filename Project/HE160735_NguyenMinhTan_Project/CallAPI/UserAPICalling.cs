using HE160735_NguyenMinhTan_Project.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HE160735_NguyenMinhTan_Project.CallAPI
{
    public class UserAPICalling
    {
        private readonly string Baseurl = "https://localhost:7015/";

        public UserAPICalling()
        {
        }

        //GET
        public async Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/User");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<User>>(Response);
                }
            }
            return users;
        }
        public async Task<User> LoginByUserPass(string user, string pass)
        {
            User account = new User();
            string urlApi = "api/User/Login?username=" + user + "&password=" + pass;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(urlApi);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    account = JsonConvert.DeserializeObject<User>(Response);
                }
                return account;
            }
        }

        public async Task<User> GetUserByUserName(string username)
        {
            User user = new User();
            string urlApi = "api/User/Get-user-by-username?username=" + username;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(urlApi);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(Response);
                }
                return user;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user = new User();
            string urlApi = "api/User/Get-user-by-email?email" + email;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(urlApi);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(Response);
                }
                return user;
            }
        }

        public async Task<User> GetUserByUsernameEmail(string username, string email)
        {
            User user = new User();
            string urlApi = "api/User/Get-user-by-username-email?username=" + username + "&email=" + email;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(urlApi);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(Response);
                }
                return user;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            User user = new User();
            string urlApi = "api/User/Get-user-by-id?id=" + id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(urlApi);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(Response);
                }
                return user;
            }
        }

        public async Task<string> SendOtp(string email)
        {
            string otp = "";
            string UrlApi = "api/User/Send-otp?email=" + email;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var message = new HttpRequestMessage(HttpMethod.Get, UrlApi);
                HttpResponseMessage response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    var Response = response.Content.ReadAsStringAsync().Result;
                    otp = JsonConvert.DeserializeObject<string>(Response);
                }
                return otp;
            }
        }

        public async Task<List<User>> FilterUser(string? username, string? phone, string? role, string? Email)
        {
            string url = "api/User/Filter-User?";
            if (username != null)
            {
                url = url + "username=" + username + "&";
            }
            if (phone != null)
            {
                url = url + "phone=" + phone + "&";
            }
            if (role != null)
            {
                url = url + "role=" + role + "&";
            }
            if (Email != null)
            {
                url = url + "Email=" + Email + "&";
            }
            List<User> users = new List<User>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(url);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<User>>(Response);
                }
                return users;
            }
        }
        
        //POST
        public async Task<string> Register(User model)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync("api/User/Register", model);
                if (response.IsSuccessStatusCode)
                {
                    return "Register Sucessfully!!";
                }
                else
                {
                    return "Register Fail!!";
                }
            }
        }
        
        //PUT
        public async Task<string> ChangePassword(string username, string password)
        {
            string UrlApi = "api/User/Change-password?username=" + username + "&password=" + password;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var message = new HttpRequestMessage(HttpMethod.Put, UrlApi);
                HttpResponseMessage response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    return "Change Password Sucessfully!!";
                }
                else
                {
                    return "Cant change password please try again";
                }
            }
        }

        public async Task UpdateUserRole(int role, int userId)
        {
            string UrlApi = "api/User/Update-Role?role=" + role + "&id=" + userId;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var message = new HttpRequestMessage(HttpMethod.Put, UrlApi);
                HttpResponseMessage response = await client.SendAsync(message);
            }
        }
        
        //DELETE
        public async Task DeleteUser(int userid)
        {
            string UrlApi = "api/User/Delete-User?id=" + userid;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var message = new HttpRequestMessage(HttpMethod.Delete, UrlApi);
                HttpResponseMessage response = await client.SendAsync(message);
            }
        }
    }
}
