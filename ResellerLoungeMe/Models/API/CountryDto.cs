using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Models.API
{
    public class CountryDto : NameDto
    {
       // public ContinentDto Continent { get; set; }
        public int ContinentId { get; set; }
    }
}
