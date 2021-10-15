using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Models.API
{
    public class CityDto : NameDto
    {
        public int CountryId { get; set; }        
    }
}
