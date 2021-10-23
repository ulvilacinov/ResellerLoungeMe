using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResellerLoungeMe.Core;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ResellerLoungeMe.Core.Interfaces;
using ResellerLoungeMe.Core.Configuration;
using ResellerLoungeMe.Core.Models.User;
using ResellerLoungeMe.Core.Models;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Infrastructure.Adapters
{
    public class TicketAdapter : ITicketAdapter
    {
        private readonly LoungeMeServer _client;
        private readonly LoungeMeServerSettings _settings;
        private readonly IActionInvoker _actionInvoker;

        public TicketAdapter(IOptions<LoungeMeServerSettings> settings, IActionInvoker actionInvoker)
        {
            _settings = settings.Value;
            _actionInvoker = actionInvoker;
            _client = LoungeMeServer.Instance(_settings);
        }

        public async Task<UserTicketDto> CreateTicketAsync(TicketDto ticket)
        {
            UserTicketDto result = new UserTicketDto();
            var response = _actionInvoker.Invoke(async () =>
           {
               return await _client.PostAsync($"{_settings.BaseUrl}/tickets",
                 new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8,
                 "application/json"));
           });

            result = JsonConvert.DeserializeObject<UserTicketDto>(await response.Result.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<UserTicketDto> GetTicketAsync(int id)
        {
            UserTicketDto result = new UserTicketDto();
            var response = _actionInvoker.Invoke(async () =>
           {
               return await _client.GetAsync($"{_settings.BaseUrl}/tickets/{id}");
           });

            result = JsonConvert.DeserializeObject<UserTicketDto>(await response.Result.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<List<UserTicketDto>> GetTicketsAsync()
        {
            List<UserTicketDto> result = new List<UserTicketDto>();
            var response = _actionInvoker.Invoke(async () =>
            {
                return await _client.GetAsync($"{_settings.BaseUrl}/tickets");
            });

            result = JsonConvert.DeserializeObject<List<UserTicketDto>>(await response.Result.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<bool> CancelTicketAsync(int id)
        {
            var response = await _client.PutAsync($"{_settings.BaseUrl}/tickets/{id}/cancel",
                new StringContent("{\"cancellationReason\":\"TRAVEL_CANCELLED\"}", Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> ShareTicketAsync(int id, ShareTicket ticket)
        {
            var response = await _client.PostAsync($"{_settings.BaseUrl}/tickets/{id}/share",
             new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8,
             "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
