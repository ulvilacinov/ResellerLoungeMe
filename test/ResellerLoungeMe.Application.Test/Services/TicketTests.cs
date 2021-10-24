using Moq;
using ResellerLoungeMe.Application.Interfaces;
using ResellerLoungeMe.Application.Models.Ticket;
using ResellerLoungeMe.Application.Services;
using ResellerLoungeMe.Core.Interfaces;
using ResellerLoungeMe.Core.Models;
using ResellerLoungeMe.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ResellerLoungeMe.Application.Test.Services
{
    public class TicketTests
    {
        private Mock<ITicketAdapter> _mockTicketAdapter;
        private readonly ITicketService _ticketService;
        public TicketTests()
        {
            _mockTicketAdapter = new Mock<ITicketAdapter>();
            _ticketService = new TicketService(_mockTicketAdapter.Object);
        }

        [Fact]
        public void CancelTicket_Should_Return_True()
        {
            _mockTicketAdapter.Setup(w => w.CancelTicketAsync(1)).Returns(Task.FromResult(true));

            var result = _ticketService.CancelTicketAsync(1).Result;

            Assert.True(result);
        }

        [Fact]
        public void ShareTicket_Should_Return_True()
        {
            var shareTicket = new Core.Models.ShareTicket { email = true, lang = "tr", phone = false };
            _mockTicketAdapter.Setup(w => w.ShareTicketAsync(1, shareTicket)).Returns(Task.FromResult(true));

            var result = _ticketService.ShareTicketAsync(1, shareTicket).Result;

            Assert.True(result);
        }

        [Fact]
        public void GetTicket_Should_Return_Correct_Result_ById()
        {
            var ticketModel = CreateTicketDetailModel();

            var ticketDto = CreateUserTicketDto();

            _mockTicketAdapter.Setup(w => w.GetTicketAsync(1)).Returns(Task.FromResult(ticketDto));

            var result = _ticketService.GetTicketAsync(1).Result;

            Assert.Equal(ticketModel.Id, result.Id);
            Assert.Equal(ticketModel.City, result.City);
            Assert.Equal(ticketModel.UserFullname, result.UserFullname);
            Assert.Equal(ticketModel.UserEmail, result.UserEmail);
            Assert.Equal(ticketModel.Terminal, result.Terminal);
            Assert.Equal(ticketModel.Status, result.Status);
            Assert.Equal(ticketModel.SoldPrice, result.SoldPrice);
            Assert.Equal(ticketModel.Pnr, result.Pnr);
            Assert.Equal(ticketModel.Lounge, result.Lounge);
            Assert.Equal(ticketModel.ExpirationDate, result.ExpirationDate);
            Assert.Equal(ticketModel.Country, result.Country);
            Assert.Equal(ticketModel.ChildCount, result.ChildCount);
            Assert.Equal(ticketModel.AdultCount, result.AdultCount);
            Assert.Equal(ticketModel.Airport, result.Airport);
            Assert.Equal(ticketModel.Direction, result.Direction);
        }

        [Fact]
        public void GetTicket_Should_Handle_Null_Data()
        {
            UserTicketDto ticketDto = new UserTicketDto
            {
                GuestEntrances = null,
                Lounge = null,
                User = null,
                Id = 1,
                Pnr = "11223344"
            };

            _mockTicketAdapter.Setup(w => w.GetTicketAsync(1)).Returns(Task.FromResult(ticketDto));

            var result = _ticketService.GetTicketAsync(1).Result;

            Assert.NotNull(result);
        }

        [Fact]
        public void GetTickets_Should_Return_Correct_Result()
        {
            List<UserTicketDto> userTicketDtoList = new List<UserTicketDto>();
            userTicketDtoList.Add(CreateUserTicketDto());

            List<TicketDisplayModel> ticketDisplayModelList = new List<TicketDisplayModel>
            {
                new TicketDisplayModel
                {
                    ChildCount = 1,
                    Created = DateTime.MinValue,
                    Id = 1,
                    Lounge = "Lounge1",
                    Pnr = "11223344",
                    Status = "ACTIVE",
                    UserEmail ="user@test.com",
                    UserFullname ="User Surname",
                    AdultCount = 2
                }
            };


            _mockTicketAdapter.Setup(w => w.GetTicketsAsync()).Returns(Task.FromResult(userTicketDtoList));

            var result = _ticketService.GetTicketsAsync().Result;

            Assert.Equal(ticketDisplayModelList.Count, result.Count);
            Assert.Equal(ticketDisplayModelList[0].Id, result[0].Id);
            Assert.Equal(ticketDisplayModelList[0].Created, result[0].Created);
            Assert.Equal(ticketDisplayModelList[0].UserFullname, result[0].UserFullname);
            Assert.Equal(ticketDisplayModelList[0].UserEmail, result[0].UserEmail);
            Assert.Equal(ticketDisplayModelList[0].Status, result[0].Status);
            Assert.Equal(ticketDisplayModelList[0].Pnr, result[0].Pnr);
            Assert.Equal(ticketDisplayModelList[0].Lounge, result[0].Lounge);
            Assert.Equal(ticketDisplayModelList[0].ChildCount, result[0].ChildCount);
            Assert.Equal(ticketDisplayModelList[0].AdultCount, result[0].AdultCount);
        }

        [Fact]
        public void GetTickets_Should_Handle_Null_Data()
        {
            List<UserTicketDto> userTicketDtoList = new List<UserTicketDto>();
            userTicketDtoList.Add(CreateUserTicketDto());

            _mockTicketAdapter.Setup(w => w.GetTicketsAsync()).Returns(Task.FromResult(userTicketDtoList));

            var result = _ticketService.GetTicketsAsync().Result;

            Assert.NotNull(result);
        }


        private UserTicketDto CreateUserTicketDto()
        {
            return new UserTicketDto
            {
                GuestEntrances = new List<GuestEntranceDto>() { new GuestEntranceDto { ChildCount = 1 } },
                Lounge = new Core.Models.Lounge.LoungeDto
                {
                    Name = "Lounge1",
                    Direction = "DEPARTURE",
                    Terminal = new TerminalDto
                    {
                        Name = "Terminal1",
                        Airport = new AirportDto
                        {
                            Name = "Frankfurt International Airpot",
                            City = new CityDto
                            {
                                Name = "Frankfurt",
                                Country = new CountryDto
                                {
                                    Name = "Germany"
                                }
                            }
                        }
                    }
                },
                ChildCount = 1,
                ExpirationDate = DateTime.MaxValue,
                Id = 1,
                Pnr = "11223344",
                SoldPrice = 12,
                State = "ACTIVE",
                Created = DateTime.MinValue,
                User = new UserDto
                {
                    Name = "User",
                    Surname = "Surname",
                    Email = "user@test.com"
                }
            };
        }

        private TicketDetailModel CreateTicketDetailModel()
        {
            return new TicketDetailModel
            {
                Id = 1,
                AdultCount = 2,
                Airport = "Frankfurt International Airpot",
                ChildCount = 1,
                City = "Frankfurt",
                Country = "Germany",
                Direction = "DEPARTURE",
                ExpirationDate = DateTime.MaxValue,
                Lounge = "Lounge1",
                Pnr = "11223344",
                SoldPrice = 12,
                Status = "ACTIVE",
                Terminal = "Terminal1",
                UserEmail = "user@test.com",
                UserFullname = "User Surname"
            };
        }
    }
}
