using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResellerLoungeMe.Core;
using ResellerLoungeMe.Core.Configuration;
using ResellerLoungeMe.Core.Interfaces;
using ResellerLoungeMe.Core.Models.Lounge;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Infrastructure.Adapters
{

    public class LoungeAdapter : ILoungeAdapter
    {
        private readonly LoungeMeClient _client;
        private readonly LoungeMeServerSettings _settings;
        private readonly IActionInvoker _actionInvoker;

        public LoungeAdapter(IOptions<LoungeMeServerSettings> settings, IActionInvoker actionInvoker)
        {
            _settings = settings.Value;
            _actionInvoker = actionInvoker;
            _client = LoungeMeClient.Instance(_settings);
        }

        public async Task<LoungeDto> GetLoungeAsync(int id)
        {
            LoungeDto result = new LoungeDto();
            var response = _actionInvoker.InvokeAsync(async () =>
            {
                return await _client.GetAsync($"{_settings.BaseUrl}/lounges/{id}");
            });

            result = JsonConvert.DeserializeObject<LoungeDto>(await response.Result.Content.ReadAsStringAsync());

            return result;
        }
    }
}
