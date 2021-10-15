using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ResellerLoungeMe.Data.APIs;
using ResellerLoungeMe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Controllers
{
    public class AirportsController : Controller
    {
        private readonly ILogger<AirportsController> _logger;
        AirportAdapter airportAdapter = new AirportAdapter();

        public AirportsController(ILogger<AirportsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAirports(string searchKey)
        {
            var airports = airportAdapter.GetAirports(searchKey).Select(item => new SelectListItem
            {
                Text = $"{item.City.Name} | {item.Name}",
                Value = item.Id.ToString()
            }).ToList();

            return Json(airports);
        }



        public IActionResult Lounges(int id)
        {
            var airportDetail = airportAdapter.GetAirport(id);
            if (airportDetail.Id == 0)
            {
                return View("NotFound");
            }
            return View(airportDetail);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
