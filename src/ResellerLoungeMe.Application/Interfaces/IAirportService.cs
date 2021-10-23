using ResellerLoungeMe.Application.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Interfaces
{
    public interface IAirportService
    {
        Task<List<SelectListItem>> GetAirportsAsync(string searchKey);
        Task<AirportModel> GetAirportAsync(int id);
    }
}
