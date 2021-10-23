using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Models.Ticket
{
    public class TicketModel
    {
        public string LoungeName { get; set; }
        public string AirportName { get; set; }
        public string Terminal { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Direction { get; set; }
        public decimal Price { get; set; }
        public string ChildPolicy { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [Display(Name="Country Code")]
        public string PhonePrefix { get; set; }
        [Required]
        public int AdultCount { get; set; } = 1;
        [Required]
        public int ChildCount { get; set; } = 0;
        [Required]
        public DateTime ExpireDate { get; set; } = DateTime.Now;
        public int LoungeId { get; set; }
    }
}
