using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ResellerLoungeMe.Data.APIs.Adapters;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ResellerLoungeMe.Data.APIs
{
    public class AirportAdapter : IAirportAdapter
    {
        LoungeMeServer client = LoungeMeServer.Instance();
        private readonly LoungeMeServerSettings _settings;

        public AirportAdapter(IOptions<LoungeMeServerSettings> settings)
        {
            _settings = settings.Value;
        }

        public List<AirportDto> GetAirports(string searchKey)
        {
            List<AirportDto> result = new List<AirportDto>();
            var response = client.GetAsync($"{_settings.BaseUrl}/reseller/search?searchKey={searchKey}").Result;
            
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<AirportDto>>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }

        public AirportDto GetAirport(int id)
        {
            AirportDto result = new AirportDto();
            var response = client.GetAsync($"{_settings.BaseUrl}/reseller/airports/{id}").Result;
            
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<AirportDto>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }
    }
}
