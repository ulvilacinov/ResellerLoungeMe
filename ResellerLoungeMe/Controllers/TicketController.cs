using Microsoft.AspNetCore.Mvc;
using QRCoder;
using ResellerLoungeMe.Data.APIs;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API;
using ResellerLoungeMe.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
           _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.GetTickets(); 
            return View(list);
        }

        public IActionResult BuyTicket(TicketViewModel ticket)
        {
            var result = _service.CreateTicket(ticket);   
            return RedirectToAction("Detail",new { id = result });
        }

        public IActionResult Detail(int id)
        {
            var result = _service.GetTicket(id);
            return View(result);
        }

        [HttpPost]
        public JsonResult Cancel(int id)
        {
            var result = _service.CancelTicket(id);
            return Json(result);
        }

        [HttpPost]
        public JsonResult SendPass(int id,ShareTicket ticket)
        {
            var result = _service.ShareTicket(id, ticket);
            return Json(result);
        }

       
    }
}
