using ResellerLoungeMe.Application.Interfaces;
using ResellerLoungeMe.Application.Models.Ticket;
using ResellerLoungeMe.Application.Utilities;
using ResellerLoungeMe.Core.Interfaces;
using ResellerLoungeMe.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketAdapter _ticketAdapter;

        public TicketService(ITicketAdapter ticketAdapter)
        {
            _ticketAdapter = ticketAdapter;
        }
        public async Task<bool> CancelTicketAsync(int id)
        {
            var result = await _ticketAdapter.CancelTicketAsync(id);

            return result;
        }

        public async Task<int> CreateTicketAsync(TicketModel ticket)
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

            var result = await _ticketAdapter.CreateTicketAsync(model);

            return result.Id;
        }

        public async Task<TicketDetailModel> GetTicketAsync(int id)
        {
            var result = await _ticketAdapter.GetTicketAsync(id);
            var qrCode = QRCodeGenerator.GenerateQrCode(result.Pnr);

            var viewModel = new TicketDetailModel()
            {
                AdultCount = result.GuestEntrances == null ? 1 : result.GuestEntrances.Count + 1,
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

        public async Task<List<TicketDisplayModel>> GetTicketsAsync()
        {
            var tickets = await _ticketAdapter.GetTicketsAsync();

            var result = tickets.Select(w => new TicketDisplayModel
            {
                ChildCount = w.ChildCount,
                Created = w.Created,
                Id = w.Id,
                Lounge = w.Lounge?.Name,
                Pnr = w.Pnr,
                Status = w.State,
                UserEmail = w.User?.Email,
                UserFullname = w.User?.Name + " " + w.User?.Surname,
                AdultCount = w.GuestEntrances == null ? 0 : w.GuestEntrances.Count + 1
            }).ToList();

            return result;
        }

        public async Task<bool> ShareTicketAsync(int id, ShareTicket ticket)
        {
            var result = await _ticketAdapter.ShareTicketAsync(id, ticket);

            return result;
        }
    }
}
