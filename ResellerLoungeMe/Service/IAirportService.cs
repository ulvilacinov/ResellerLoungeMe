using Microsoft.AspNetCore.Mvc.Rendering;
using ResellerLoungeMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Service
{
    public interface IAirportService
    {
        List<SelectListItem> GetAirports(string searchKey);
        AirportViewModel GetAirport(int id);
        void GetAndSetAirportsCache();
    }
}
