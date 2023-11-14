using HE160735_NguyenMinhTan_Project.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HE160735_NguyenMinhTan_Project.CallAPI
{
    public class BookAPICalling
    {
        private readonly string Baseurl = "https://localhost:7015/";
        public BookAPICalling()
        {
        }

        //GET
        public async Task<List<Book>> GetBooks()
        {
            List<Book> books = new List<Book>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Book");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    books = JsonConvert.DeserializeObject<List<Book>>(Response);
                }
            }
            return books;
        }

        public async Task<List<Book>> GetBookByUserId(int userId)
        {
            List<Book> books = new List<Book>();
            string urlApi = "api/Book/Get-books-by-user-id?userId=" + userId;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(urlApi);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    books = JsonConvert.DeserializeObject<List<Book>>(Response);
                }
                return books;
            }
        }

        public async Task<List<Book>> FilterBook(string? name, string? phone, string? bookdate, string? booktime)
        {
            string url = "api/Book/Filter-Book?";
            if (name != null)
            {
                url = url + "name=" + name + "&";
            }
            if (phone != null)
            {
                url = url + "phone=" + phone + "&";
            }
            if (bookdate != null)
            {
                url = url + "bookdate=" + bookdate + "&";
            }
            if (booktime != null)
            {
                url = url + "booktime=" + booktime + "&";
            }
            List<Book> books = new List<Book>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(url);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    books = JsonConvert.DeserializeObject<List<Book>>(Response);
                }
                return books;
            }
        }

        //POST
        public async Task<string> AddBook(Book model)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Book/Add-book", model);
                if (response.IsSuccessStatusCode)
                {
                    return "Thank for booking wait a minute for verify!";
                }
                else
                    return "Add Fail!!";
            }
        }

        //PUT
        public async Task ReplaceBookUserId(int guestId, int userId)
        {
            string UrlApi = "api/Book/Update-book?guestId=" + guestId + "&userId=" + userId;
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
        public async Task DeleteBook(int bookid)
        {
            string UrlApi = "api/Book/Delete-book?id=" + bookid;
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
