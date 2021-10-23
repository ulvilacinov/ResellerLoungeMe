using System.Collections.Generic;

namespace ResellerLoungeMe.Core.Models
{
    public class AirportDto: NameDto
    {
        public CityDto City { get; set; }
        public int CityId { get; set; }
        public string Code { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string UrlPostfix { get; set; }
        public ICollection<TerminalDto> Terminals { get; set; }

    }
}
