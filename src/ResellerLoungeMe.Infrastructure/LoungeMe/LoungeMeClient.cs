using Newtonsoft.Json.Linq;
using ResellerLoungeMe.Core.Configuration;
using ResellerLoungeMe.Core.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ResellerLoungeMe.Core
{
    public sealed class LoungeMeClient : HttpClient
    {
        private static readonly LoungeMeClient instance = new LoungeMeClient();
        private static LoungeMeServerSettings _settings;

        private LoungeMeClient() { }

        public static LoungeMeClient Instance(LoungeMeServerSettings settings)
        {
            _settings = settings;
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
                       JsonSerializer.Serialize(new LoginModel { email = _settings.Email, password = _settings.Password }, typeof(object), new JsonSerializerOptions()),
                       Encoding.UTF8, "application/json");
                request.RequestUri = new Uri($"{_settings.BaseUrl}/login");
                var response = httpClient.SendAsync(request).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                tokenCreatedDate = DateTime.Now;
                JObject jObj = JObject.Parse(result);

                return jObj["authToken"].ToString();
            }

        }
    }
}
