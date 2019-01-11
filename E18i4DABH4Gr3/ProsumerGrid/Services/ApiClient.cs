using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ProsumerGrid.Services
{
    public class ApiClient<Entity, EntityDTO>
    {
        public HttpClient Client { get; set; }

        private string _name;
        public ApiClient(string baseaddress = "http://localhost:14065/api/")
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(baseaddress);
        }

        public HttpResponseMessage GetResponse(string url)
        {
            var responseTask = Client.GetAsync(url);
            responseTask.Wait();
            return responseTask.Result;
            //return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage Put(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage Post(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage Delete(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}