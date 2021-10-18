using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResellerLoungeMe.Data.APIs.Adapters;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API;
using ResellerLoungeMe.Models.API.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Data.APIs
{
    public class TicketAdapter : ITicketAdapter
    {
        LoungeMeServer client = LoungeMeServer.Instance();
        private readonly LoungeMeServerSettings _settings;

        public TicketAdapter(IOptions<LoungeMeServerSettings> settings)
        {
            _settings = settings.Value;
        }

        public UserTicketDto CreateTicket(TicketDto ticket)
        {
            UserTicketDto result = new UserTicketDto();
            var response = client.PostAsync($"{_settings.BaseUrl}/reseller/tickets", 
                new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, 
                "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<UserTicketDto>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }

        public UserTicketDto GetTicket(int id)
        {
            UserTicketDto result = new UserTicketDto();
            var response = client.GetAsync($"{_settings.BaseUrl}/reseller/tickets/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<UserTicketDto>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }

        public List<UserTicketDto> GetTickets()
        {
            List<UserTicketDto> result = new List<UserTicketDto>();
            var response = client.GetAsync($"{_settings.BaseUrl}/reseller/tickets").Result;

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<UserTicketDto>>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }

        public  bool CancelTicket(int id)
        {
            var response = client.PutAsync($"{_settings.BaseUrl}/reseller/tickets/{id}/cancel", 
                new StringContent("{\"cancellationReason\":\"TRAVEL_CANCELLED\"}", Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public bool ShareTicket(int id, ShareTicket ticket)
        {
            var response = client.PostAsync($"{_settings.BaseUrl}/reseller/tickets/{id}/share",
             new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8,
             "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
