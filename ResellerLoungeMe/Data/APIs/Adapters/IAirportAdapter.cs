using ResellerLoungeMe.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Data.APIs.Adapters
{
    public interface IAirportAdapter
    {
        List<AirportDto> GetAirports(string searchKey);
        AirportDto GetAirport(int id);
    }
}
