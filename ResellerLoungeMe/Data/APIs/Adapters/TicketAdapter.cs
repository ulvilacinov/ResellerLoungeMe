﻿using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResellerLoungeMe.Data.APIs.Adapters;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API;
using ResellerLoungeMe.Models.API.User;
using ResellerLoungeMe.Utilities;
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
        private readonly LoungeMeServer _client;
        private readonly LoungeMeServerSettings _settings;
        private readonly IActionInvoker _actionInvoker;

        public TicketAdapter(IOptions<LoungeMeServerSettings> settings, IActionInvoker actionInvoker)
        {
            _settings = settings.Value;
            _actionInvoker = actionInvoker;
            _client = LoungeMeServer.Instance(_settings);
        }

        public UserTicketDto CreateTicket(TicketDto ticket)
        {
            UserTicketDto result = new UserTicketDto();
            var response = _actionInvoker.Invoke(() =>
           {
               return _client.PostAsync($"{_settings.BaseUrl}/tickets",
                 new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8,
                 "application/json")).Result;
           });

            result = JsonConvert.DeserializeObject<UserTicketDto>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public UserTicketDto GetTicket(int id)
        {
            UserTicketDto result = new UserTicketDto();
            var response = _actionInvoker.Invoke(() =>
           {
               return _client.GetAsync($"{_settings.BaseUrl}/tickets/{id}").Result;
           });

            result = JsonConvert.DeserializeObject<UserTicketDto>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public List<UserTicketDto> GetTickets()
        {
            List<UserTicketDto> result = new List<UserTicketDto>();
            var response = _actionInvoker.Invoke(() =>
            {
                return _client.GetAsync($"{_settings.BaseUrl}/tickets").Result;
            });

            result = JsonConvert.DeserializeObject<List<UserTicketDto>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public bool CancelTicket(int id)
        {
            var response = _client.PutAsync($"{_settings.BaseUrl}/tickets/{id}/cancel",
                new StringContent("{\"cancellationReason\":\"TRAVEL_CANCELLED\"}", Encoding.UTF8, "application/json")).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public bool ShareTicket(int id, ShareTicket ticket)
        {
            var response = _client.PostAsync($"{_settings.BaseUrl}/tickets/{id}/share",
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
