using ResellerLoungeMe.Models.API;
using ResellerLoungeMe.Models.API.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Data.APIs.Adapters
{
    public interface ITicketAdapter
    {
        UserTicketDto CreateTicket(TicketDto ticket);
        UserTicketDto GetTicket(int id);
        List<UserTicketDto> GetTickets();
        bool CancelTicket(int id);
        bool ShareTicket(int id, ShareTicket ticket);
    }
}
