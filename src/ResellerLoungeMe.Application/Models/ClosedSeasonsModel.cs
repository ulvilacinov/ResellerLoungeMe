using System;

namespace ResellerLoungeMe.Application.Models
{
    public class ClosedSeasonsModel
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}