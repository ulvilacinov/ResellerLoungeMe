using Microsoft.AspNetCore.Mvc;
using ResellerLoungeMe.Data.APIs;
using ResellerLoungeMe.Models.API;
using ResellerLoungeMe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Controllers
{
    public class LoungeController : Controller
    {
        private readonly ILoungeService _service;

        public LoungeController(ILoungeService service)
        {
            _service = service;
        }
        public IActionResult Index(int id)
        {
            var result = _service.GetLounge(id);
            return View(result);
        }
    }
}
