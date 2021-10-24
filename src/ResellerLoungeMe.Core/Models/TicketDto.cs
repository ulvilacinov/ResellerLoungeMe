
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Models
{
    public class TicketDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int loungeId { get; set; }
        public int adultCount { get; set; }
        public int childCount { get; set; }
        public DateTime expireDate { get; set; }
        public int phonePrefixLength { get; set; }
    }
}
