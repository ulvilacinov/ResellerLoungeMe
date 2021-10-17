using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Models
{
    public class TicketDisplayViewModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string UserFullname { get; set; }
        public string UserEmail { get; set; }
        public string Status { get; set; }
        public string Lounge { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public string Pnr { get; set; }
    }
}
