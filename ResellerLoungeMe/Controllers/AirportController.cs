﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ResellerLoungeMe.Data.APIs;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public JsonResult GetAirports(string searchKey)
        {
            var airports = _service.GetAirports(searchKey);

            return Json(airports);
        }

        public IActionResult Lounges(int id)
        {
            var airportDetail = _service.GetAirport(id);
            if (airportDetail == null)
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

        public ActionResult Test()
        {
            return View("NotFound");
        }
    }
}