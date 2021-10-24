using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResellerLoungeMe.Core;
using ResellerLoungeMe.Core.Configuration;
using ResellerLoungeMe.Core.Interfaces;
using ResellerLoungeMe.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Infrastructure.Adapters
{
    public class AirportAdapter : IAirportAdapter
    {
        private readonly LoungeMeServerSettings _settings;
        private readonly IActionInvoker _actionInvoker;
        private readonly LoungeMeClient _client;

        public AirportAdapter(IOptions<LoungeMeServerSettings> settings, IActionInvoker actionInvoker)
        {
            _settings = settings.Value;
            _actionInvoker = actionInvoker;
            _client = LoungeMeClient.Instance(_settings);
        }

        public async Task<List<AirportDto>> GetAirportsAsync(string searchKey)
        {
            List<AirportDto> result = new List<AirportDto>();

            var response = _actionInvoker.InvokeAsync(async () =>
            {
                return await _client.GetAsync($"{_settings.BaseUrl}/search?searchKey={searchKey}");
            });

            result = JsonConvert.DeserializeObject<List<AirportDto>>(await response.Result.Content.ReadAsStringAsync());
            
            return result;
        }

        public async Task<AirportDto> GetAirportAsync(int id)
        {
            AirportDto result = new AirportDto();

            var response = _actionInvoker.InvokeAsync(async() =>
            {
                return await _client.GetAsync($"{_settings.BaseUrl}/airports/{id}");
            });

            result = JsonConvert.DeserializeObject<AirportDto>(await response.Result.Content.ReadAsStringAsync());

            return result;
        }
    }
}
