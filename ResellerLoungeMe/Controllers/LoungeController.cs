using Microsoft.AspNetCore.Mvc;
using ResellerLoungeMe.Data.APIs;
using ResellerLoungeMe.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Controllers
{
    public class LoungeController : Controller
    {
        LoungeAdapter loungeAdapter = new LoungeAdapter();
        public IActionResult Index(int id)
        {
            var result = loungeAdapter.GetLounge(id);
            if (result.Id == 0)
            {
                return View("NotFound");
            }
            return View(result);
        }
    }
}
