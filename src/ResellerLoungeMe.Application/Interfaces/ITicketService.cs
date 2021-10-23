using ResellerLoungeMe.Application.Models.Ticket;
using ResellerLoungeMe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Interfaces
{
    public interface ITicketService
    {
        Task<int> CreateTicketAsync(TicketModel ticket);
        Task<TicketDetailModel> GetTicketAsync(int id);
        Task<List<TicketDisplayModel>> GetTicketsAsync();
        Task<bool> CancelTicketAsync(int id);
        Task<bool> ShareTicketAsync(int id, ShareTicket ticket);
    }
}
