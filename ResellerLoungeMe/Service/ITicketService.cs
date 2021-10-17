using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Service
{
    public interface ITicketService
    {
        int CreateTicket(TicketViewModel ticket);
        TicketDetailViewModel GetTicket(int id);
        List<TicketDisplayViewModel> GetTickets();
        bool CancelTicket(int id);
        bool ShareTicket(int id, ShareTicket ticket);
    }
}
