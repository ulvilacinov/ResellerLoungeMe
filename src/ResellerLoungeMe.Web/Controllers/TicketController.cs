using Microsoft.AspNetCore.Mvc;
using ResellerLoungeMe.Application.Interfaces;
using ResellerLoungeMe.Application.Models.Ticket;
using ResellerLoungeMe.Core.Models;
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

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetTicketsAsync(); 
            return View(list);
        }

        public async Task<IActionResult> BuyTicket(TicketModel ticket)
        {
            var result = await _service.CreateTicketAsync(ticket);   
            return RedirectToAction("Detail",new { id = result });
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _service.GetTicketAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> Cancel(int id)
        {
            var result = await _service.CancelTicketAsync(id);
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> SendPass(int id,ShareTicket ticket)
        {
            var result = await _service.ShareTicketAsync(id, ticket);
            return Json(result);
        }

       
    }
}
