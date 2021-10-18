using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ResellerLoungeMe.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ResellerLoungeMe.Data.APIs
{
    public sealed class LoungeMeServer: HttpClient
    {
        private static readonly LoungeMeServer instance = new LoungeMeServer();
        private LoungeMeServer() { }
     
        public static LoungeMeServer Instance()
        {
            instance.DefaultRequestHeaders.Clear();
            instance.DefaultRequestHeaders.Add("x-loungeme-auth-token", CreateToken());
            instance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return instance;
        }

        static DateTime tokenCreatedDate;
        static string token = string.Empty;
        static string CreateToken()
        {
            if (string.IsNullOrEmpty(token) || DateTime.Now.Subtract(tokenCreatedDate).TotalMinutes > 55)
            {
                token = GetToken();
            }
            return token;
        }

        static string GetToken()
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(
                       System.Text.Json.JsonSerializer.Serialize(new LoginModel { email= "test@agency.com", password= "lounge123Me321" }, typeof(object), new JsonSerializerOptions()),
                       Encoding.UTF8, "application/json");
                request.RequestUri = new Uri("https://api.slowfoodtime.com/reseller/login");
                var response = httpClient.SendAsync(request).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                tokenCreatedDate = DateTime.Now;
                JObject jObj = JObject.Parse(result);

                return jObj["authToken"].ToString();
            }
           
        }
    }
}
