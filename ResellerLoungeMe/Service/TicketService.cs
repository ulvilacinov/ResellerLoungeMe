using ResellerLoungeMe.Data.APIs.Adapters;
using ResellerLoungeMe.Models;
using ResellerLoungeMe.Models.API;
using ResellerLoungeMe.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketAdapter _ticketAdapter;

        public TicketService(ITicketAdapter ticketAdapter)
        {
            _ticketAdapter = ticketAdapter;
        }
        public bool CancelTicket(int id)
        {
            var result = _ticketAdapter.CancelTicket(id);

            return result;
        }

        public int CreateTicket(TicketViewModel ticket)
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

            var result = _ticketAdapter.CreateTicket(model).Id;

            return result;
        }

        public TicketDetailViewModel GetTicket(int id)
        {
            var result = _ticketAdapter.GetTicket(id);
            var qrCode = QRCodeGenerator.GenerateQrCode(result.Pnr);

            var viewModel = new TicketDetailViewModel()
            {
                AdultCount = result.GuestEntrances.Count + 1,
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

            return viewModel;
        }

        public List<TicketDisplayViewModel> GetTickets()
        {
            var result = _ticketAdapter.GetTickets().Select(w => new TicketDisplayViewModel
            {
                ChildCount = w.ChildCount,
                Created = w.Created,
                Id = w.Id,
                Lounge = w.Lounge.Name,
                Pnr = w.Pnr,
                Status = w.State,
                UserEmail = w.User?.Email,
                UserFullname = w.User?.Name + " " + w.User?.Surname,
                AdultCount = w.GuestEntrances.Count
            }).ToList();

            return result;
        }

        public bool ShareTicket(int id, ShareTicket ticket)
        {
            var result = _ticketAdapter.ShareTicket(id, ticket);

            return result;
        }
    }
}
