using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResellerLoungeMe.Data.APIs.Adapters;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API.Lounge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Data.APIs
{
    
    public class LoungeAdapter: ILoungeAdapter
    {
        LoungeMeServer client = LoungeMeServer.Instance();
        private readonly LoungeMeServerSettings _settings;
        public LoungeAdapter(IOptions<LoungeMeServerSettings> settings)
        {
            _settings = settings.Value;
        }

        public LoungeDto GetLounge(int id)
        {
            LoungeDto result = new LoungeDto();
            var response = client.GetAsync($"{_settings.BaseUrl}/reseller/lounges/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<LoungeDto>(response.Content.ReadAsStringAsync().Result);
            }
            return result;
        }
    }
}
