using HE160735_NguyenMinhTan_Project.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HE160735_NguyenMinhTan_Project.CallAPI
{
    public class CategoryAPICalling
    {
        private readonly string Baseurl = "https://localhost:7015/";
        public CategoryAPICalling()
        {
        }

        //GET
        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Category");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    categories = JsonConvert.DeserializeObject<List<Category>>(Response);
                }
            }
            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            Category category = new Category();
            string urlApi = "api/Category/Get-category-by-id?id=" + id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(urlApi);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    category = JsonConvert.DeserializeObject<Category>(Response);
                }
                return category;
            }
        }

        public async Task<Category> GetCategoryByCateName(string cateName)
        {
            Category category = new Category();
            string urlApi = "api/Category/Get-category-by-category-name?categoryName=" + cateName;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(urlApi);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    category = JsonConvert.DeserializeObject<Category>(Response);
                }
                return category;
            }
        }

        //POST
        public async Task CreateCategory(string cateName)
        {
            string UrlApi = "api/Category/Create-category?categoryName=" + cateName;
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var message = new HttpRequestMessage(HttpMethod.Post, UrlApi);
                HttpResponseMessage response = await client.SendAsync(message);
            }
        }

        //PUT
        public async Task UpdateCategory(string cateId, string cateName)
        {
            string UrlApi = "api/Category/Update-category?id=" + cateId + "&categoryName=" + cateName;
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
        public async Task DeleteCategory(string cateId)
        {
            string UrlApi = "api/Category/Delete-category?id=" + cateId;
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
