using Microsoft.AspNetCore.Mvc;
using ResellerLoungeMe.Data.APIs;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Controllers
{
    public class TicketController : Controller
    {
        TicketAdapter ticketAdapter = new TicketAdapter();
        public IActionResult Index()
        {
            var list = ticketAdapter.GetTickets().Select(w=> new TicketDisplayViewModel
            {
                ChildAdult = w.ChildCount,
                Created = w.Created,
                Id = w.Id,
                Lounge = w.Lounge.Name,
                Pnr = w.Pnr,
                Status = w.State,
                UserEmail = w.User?.Email,
                UserFullname = w.User?.Name+ " " + w.User?.Surname,
                AdultCount = w.GuestEntrances.Count
            }).ToList();
            return View(list);
        }

        public IActionResult BuyTicket(TicketViewModel ticket)
        {
            var model = new TicketDto
            {
                adultCount = ticket.AdultCount,
                childCount = ticket.ChildCount,
                email = ticket.Email,
                expireDate = ticket.ExpireDate,
                loungeId = ticket.LoungeId,
                name = ticket.Name,
                phone = ticket.PhonePrefix + ticket.Phone,
                phonePrefixLength = ticket.PhonePrefix.Length,
                surname = ticket.Surname
            };
            var result = ticketAdapter.CreateTicket(model);
            
            return RedirectToAction("Detail",new { id = result.Id });
        }

        public IActionResult Detail(int id)
        {
            var result = ticketAdapter.GetTicket(id);
            return View(result);
        }
    }
}
