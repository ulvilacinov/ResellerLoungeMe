using Newtonsoft.Json;
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
    public class TicketAdapter
    {
        LoungeMeServer client = LoungeMeServer.Instance();
        const string BaseUrl = "https://api.slowfoodtime.com";
        public ResultTicketDto CreateTicket(TicketDto ticket)
        {
            ResultTicketDto result = new ResultTicketDto();
            var response = client.PostAsync($"{BaseUrl}/reseller/tickets", 
                new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, 
                "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<ResultTicketDto>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }
        public UserTicketDto GetTicket(int id)
        {
            UserTicketDto result = new UserTicketDto();
            var response = client.GetAsync($"{BaseUrl}/reseller/tickets/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<UserTicketDto>(response.Content.ReadAsStringAsync().Result);
            }
            return result;
        }

        public List<UserTicketDto> GetTickets()
        {
            List<UserTicketDto> result = new List<UserTicketDto>();
            var response = client.GetAsync($"{BaseUrl}/reseller/tickets").Result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<List<UserTicketDto>>(response.Content.ReadAsStringAsync().Result);
            }
            return result;
        }
    }
}
