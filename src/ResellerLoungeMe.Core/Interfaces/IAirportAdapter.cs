using ResellerLoungeMe.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Interfaces
{
    public interface IAirportAdapter
    {
        Task<List<AirportDto>> GetAirportsAsync(string searchKey);
        Task<AirportDto> GetAirportAsync(int id);
    }
}
