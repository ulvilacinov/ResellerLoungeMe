using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Models.API
{
    public class TerminalDto : NameDto
    {
        public int AirportId { get; set; }
        public AirportDto Airport { get; set; }
        public ICollection<LoungeDto> Lounges { get; set; }
    }
}
