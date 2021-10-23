using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Models
{
    public class CityDto : NameDto
    {
        public CountryDto Country { get; set; }
        public int CountryId { get; set; }        
    }
}
