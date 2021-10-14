using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Models.API
{
    public class AirportDto: NameDto
    {
        public int CityId { get; set; }
        public string Code { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string UrlPostfix { get; set; }
        public ICollection<TerminalDto> Terminals { get; set; }
    }
}
