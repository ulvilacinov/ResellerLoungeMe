using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Models.Ticket
{
    public class TicketDetailModel
    {
        public int Id { get; set; }
        public string Lounge { get; set; }
        public string Airport { get; set; }
        public string Terminal { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Direction { get; set; }
        public string UserFullname { get; set; }
        public string UserEmail { get; set; }
        public string Status { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public decimal SoldPrice { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Pnr { get; set; }
        public string QrCode { get; set; }
    }
}
