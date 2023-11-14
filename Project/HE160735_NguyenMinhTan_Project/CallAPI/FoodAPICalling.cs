using HE160735_NguyenMinhTan_Project.Models;
using HE160735_NguyenMinhTan_Project_API.ModelDTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HE160735_NguyenMinhTan_Project.CallAPI
{
    public class FoodAPICalling
    {
        private readonly string Baseurl = "https://localhost:7015/";
        public FoodAPICalling()
        {
        }

        //GET 
        public async Task<List<Food>> GetFoods()
        {
            List<Food> foods = new List<Food>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Food");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    foods = JsonConvert.DeserializeObject<List<Food>>(Response);
                }
            }
            return foods;
        }

        public async Task<Food> GetFoodById(int id)
        {
            Food food = new Food();
            string urlApi = "api/Food/Get-food-by-id?id=" + id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(urlApi);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    food = JsonConvert.DeserializeObject<Food>(Response);
                }
                return food;
            }
        }

        public async Task<List<Food>> GetFoodsByCateId(string cateId)
        {
            List<Food> foods = new List<Food>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Food/List-food-by-cateid?id=" + cateId);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    foods = JsonConvert.DeserializeObject<List<Food>>(Response);
                }
            }
            return foods;
        }

        public async Task<List<Food>> FilterFood(string? foodname, string? foodprice, string? category, string? fooddescription, string? foodpricefrom, string? foodpriceto)
        {
            string url = "api/Food/Filter-Food?";
            if (foodname != null)
            {
                url = url + "foodname=" + foodname + "&";
            }
            if (foodprice != null)
            {
                url = url + "foodprice=" + foodprice + "&";
            }
            if (category != null)
            {
                url = url + "category=" + category + "&";
            }
            if (fooddescription != null)
            {
                url = url + "fooddescription=" + fooddescription + "&";
            }
            if (foodpricefrom != null)
            {
                url = url + "foodpricefrom=" + foodpricefrom + "&";
            }
            if (foodpriceto != null)
            {
                url = url + "foodpriceto=" + foodpriceto + "&";
            }
            List<Food> foods = new List<Food>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(url);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    foods = JsonConvert.DeserializeObject<List<Food>>(Response);
                }
                return foods;
            }
        }
        
        //PUT
        public async Task UpdateFood(FoodDTO model)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Food/Update-food", model);
            }
        }

        //DELETE
        public async Task DeleteFood(int foodid)
        {
            string UrlApi = "api/Food/Delete-Food?id=" + foodid;
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
