using Microsoft.AspNetCore.Mvc;
using QRCoder;
using ResellerLoungeMe.Data.APIs;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API;
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
        TicketAdapter ticketAdapter = new TicketAdapter();
        public IActionResult Index()
        {
            var list = ticketAdapter.GetTickets().Select(w=> new TicketDisplayViewModel
            {
                ChildCount = w.ChildCount,
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
            var qrCode = GenerateQrCode(result.Pnr);

            var viewModel = new TicketDetailViewModel()
            {
                AdultCount = result.GuestEntrances.Count,
                Airport = result.Lounge?.Terminal?.Airport?.Name,
                ChildCount = result.ChildCount,
                City = result.Lounge?.Terminal?.Airport?.City.Name,
                Country = result.Lounge?.Terminal?.Airport?.City?.Country?.Name,
                Direction = result.Lounge?.Direction,
                ExpirationDate = result.ExpirationDate,
                Id = result.Id,
                Lounge = result.Lounge?.Name,
                Pnr = result.Pnr,
                SoldPrice = result.SoldPrice,
                Status = result.State,
                Terminal = result.Lounge?.Terminal?.Name,
                UserEmail = result.User?.Email,
                UserFullname = result.User?.Name + " " + result.User?.Surname,
                QrCode = qrCode
            };
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Cancel(int id)
        {
            var result = ticketAdapter.CancelTicket(id);
            return Json(result);
        }

        [HttpPost]
        public JsonResult SendPass(int id,ShareTicket ticket)
        {
            var result = ticketAdapter.ShareTicket(id, ticket);
            return Json(result);
        }

        private string GenerateQrCode(string pnr)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(pnr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            System.IO.MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            return Convert.ToBase64String(byteImage);
        }
    }
}
