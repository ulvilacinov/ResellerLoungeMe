using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ResellerLoungeMe.Models.API;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ResellerLoungeMe.Data.APIs
{
    public class AirportAdapter
    {
        LoungeMeServer client = LoungeMeServer.Instance();
        const string BaseUrl = "https://api.slowfoodtime.com";
        public List<AirportDto> GetAirports()
        {
            List<AirportDto> result = new List<AirportDto>();
            var response = client.GetAsync($"{BaseUrl}/reseller/airports").Result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<AirportDto>>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }

        public List<AirportDto> GetAirports(string searchKey)
        {
            List<AirportDto> result = new List<AirportDto>();
            var response = client.GetAsync($"{BaseUrl}/reseller/search?searchKey={searchKey}").Result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<AirportDto>>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }

        public AirportDto GetAirport(int id)
        {
            AirportDto result = new AirportDto();
            var response = client.GetAsync($"{BaseUrl}/reseller/airports/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<AirportDto>(response.Content.ReadAsStringAsync().Result);
            }
            result.SelectListTerminals = result.Terminals?.Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() }).ToList();
            return result;
        }
    }
}
