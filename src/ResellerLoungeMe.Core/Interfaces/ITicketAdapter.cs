using ResellerLoungeMe.Core.Models;
using ResellerLoungeMe.Core.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Interfaces
{
    public interface ITicketAdapter
    {
        Task<UserTicketDto> CreateTicketAsync(TicketDto ticket);
        Task<UserTicketDto> GetTicketAsync(int id);
        Task<List<UserTicketDto>> GetTicketsAsync();
        Task<bool> CancelTicketAsync(int id);
        Task<bool> ShareTicketAsync(int id, ShareTicket ticket);
    }
}
