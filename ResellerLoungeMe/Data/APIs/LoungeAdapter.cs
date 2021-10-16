using Newtonsoft.Json;
using ResellerLoungeMe.Models.API.Lounge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Data.APIs
{
    
    public class LoungeAdapter
    {
        LoungeMeServer client = LoungeMeServer.Instance();
        const string BaseUrl = "https://api.slowfoodtime.com";

        public LoungeDto GetLounge(int id)
        {
            LoungeDto result = new LoungeDto();
            var response = client.GetAsync($"{BaseUrl}/reseller/lounges/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<LoungeDto>(response.Content.ReadAsStringAsync().Result);
            }
            return result;
        }
    }
}
