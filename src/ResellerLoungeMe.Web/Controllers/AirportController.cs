using Microsoft.AspNetCore.Mvc;
using ResellerLoungeMe.Application.Interfaces;
using ResellerLoungeMe.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportService _service;

        public AirportController(IAirportService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetAirports(string searchKey)
        {
            var airports =await _service.GetAirportsAsync(searchKey);

            return Json(airports);
        }

        public async Task<IActionResult> Lounges(int id)
        {
            var airportDetail =await _service.GetAirportAsync(id);
            if (airportDetail == null)
            {
                return View("NotFound");
            }
            return View(airportDetail);
        }

    }
}
