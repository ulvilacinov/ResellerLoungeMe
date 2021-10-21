using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResellerLoungeMe.Data.APIs.Adapters;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API.Lounge;
using ResellerLoungeMe.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Data.APIs
{

    public class LoungeAdapter : ILoungeAdapter
    {
        private readonly LoungeMeServer _client;
        private readonly LoungeMeServerSettings _settings;
        private readonly IActionInvoker _actionInvoker;

        public LoungeAdapter(IOptions<LoungeMeServerSettings> settings, IActionInvoker actionInvoker)
        {
            _settings = settings.Value;
            _actionInvoker = actionInvoker;
            _client = LoungeMeServer.Instance(_settings);
        }

        public LoungeDto GetLounge(int id)
        {
            LoungeDto result = new LoungeDto();
            var response = _actionInvoker.Invoke(() =>
            {
                return _client.GetAsync($"{_settings.BaseUrl}/lounges/{id}").Result;
            });

            result = JsonConvert.DeserializeObject<LoungeDto>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
    }
}
