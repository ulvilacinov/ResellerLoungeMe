using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using ResellerLoungeMe.Application.Interfaces;
using ResellerLoungeMe.Application.Models;
using ResellerLoungeMe.Application.Services;
using ResellerLoungeMe.Core.Interfaces;
using ResellerLoungeMe.Core.Models;
using ResellerLoungeMe.Core.Models.Lounge;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ResellerLoungeMe.Application.Test
{
    public class AirportTests
    {

        private Mock<IAirportAdapter> _mockAirportAdapter;
        private readonly IAirportService _airportService;

        public AirportTests()
        {
            _mockAirportAdapter = new Mock<IAirportAdapter>();
            _airportService = new AirportService(_mockAirportAdapter.Object);
        }

        [Fact]
        public void GetAirtport_Should_Handle_Null_Data()
        {
            AirportDto airportDto = new AirportDto
            {
                Id = 1,
                City = null,
                Name = "Frankfurt Airport",
                Terminals = null
            };

            _mockAirportAdapter.Setup(w => w.GetAirportAsync(1)).Returns(Task.FromResult(airportDto));

            var result = _airportService.GetAirportAsync(1).Result;

            Assert.NotNull(result);
        }

        [Fact]
        public void GetAirtport_Should_Return_Correct_Result_By_Id()
        {
            AirportModel airportModel = new AirportModel
            {
                Id = 1,
                City = "Frankfurt",
                Name = "Frankfurt Airport",
                SelectListTerminals = new List<SelectListItem>() { new SelectListItem { Text = "Terminal1", Value = "1" } },
                Terminals = new List<TerminalModel>() { new TerminalModel {
                    Id = 1,
                    Name = "Terminal1",
                    Lounges = new List<LoungeModel>() { new LoungeModel {
                        Id = 12,
                        Name = "LoungeName",
                        Price = 12,
                        Images = new List<ImageModel>() { new ImageModel {
                            OrderIndex = "1",
                            Url = "path" }
                        }
                    }
                    }
                }
                }
            };

            AirportDto airportDto = new AirportDto
            {
                Id = 1,
                City = new CityDto
                {
                    Name = "Frankfurt"
                },
                Name = "Frankfurt Airport",
                Terminals = new List<TerminalDto>() { new TerminalDto {
                    Id = 1,
                    Name = "Terminal1",
                    Lounges = new List<LoungeDto>() { new LoungeDto {
                        Id = 12,
                        Name = "LoungeName",
                        Price = 12,
                        Images = new List<LoungeImageDto>() { new LoungeImageDto {
                            OrderIndex = "1",
                            Url = "path" }
                        }
                    }
                    }
                }
                }
            };

            _mockAirportAdapter.Setup(w => w.GetAirportAsync(1)).Returns(Task.FromResult(airportDto));

            var result = _airportService.GetAirportAsync(1).Result;

            Assert.Equal(airportModel.Id, result.Id);
            Assert.Equal(airportModel.City, result.City);
            Assert.Equal(airportModel.Name, result.Name);
            Assert.Equal(airportModel.SelectListTerminals[0].Text, result.SelectListTerminals[0].Text);
            Assert.Equal(airportModel.SelectListTerminals[0].Value, result.SelectListTerminals[0].Value);
            Assert.Equal(airportModel.Terminals[0].Name, result.Terminals[0].Name);
            Assert.Equal(airportModel.Terminals[0].Lounges[0].Id, result.Terminals[0].Lounges[0].Id);
            Assert.Equal(airportModel.Terminals[0].Lounges[0].Name, result.Terminals[0].Lounges[0].Name);
            Assert.Equal(airportModel.Terminals[0].Lounges[0].Price, result.Terminals[0].Lounges[0].Price);
            Assert.Equal(airportModel.Terminals[0].Lounges[0].Images[0].OrderIndex, result.Terminals[0].Lounges[0].Images[0].OrderIndex);
            Assert.Equal(airportModel.Terminals[0].Lounges[0].Images[0].Url, result.Terminals[0].Lounges[0].Images[0].Url);
        }

        [Fact]
        public void GetAirports_Should_Handle_Null_Data()
        {
            List<AirportDto> airportDtoList = new List<AirportDto>
            {
                 new AirportDto { Id = 1, City = null, Name = "Frankfurt Airport" },
            };

            _mockAirportAdapter.Setup(w => w.GetAirportsAsync("fran")).Returns(Task.FromResult(airportDtoList));

            var result = _airportService.GetAirportsAsync("fran").Result;

            Assert.NotNull(result);

        }

        [Fact]
        public void GetAirports_Should_Return_Correct_Result_By_Searchkey()
        {
            List<AirportDto> airportDtoList = new List<AirportDto>
            {
                 new AirportDto { Id = 1, City = new CityDto{ Name = "Frankfurt" }, Name = "Frankfurt Airport" },
                 new AirportDto { Id = 2, City = new CityDto{ Name = "Baku", }, Name = "Heyder Aliyev Airport" },
            };

            List<SelectListItem> expectedModel = new List<SelectListItem>
            {
                new SelectListItem { Text = "Frankfurt | Frankfurt Airport", Value = "1"},
                new SelectListItem { Text = "Baku | Heyder Aliyev Airport", Value = "2"},
            };

            _mockAirportAdapter.Setup(w => w.GetAirportsAsync("a")).Returns(Task.FromResult(airportDtoList));

            var result = _airportService.GetAirportsAsync("a").Result;

            Assert.Equal(expectedModel.Count, result.Count);
            Assert.Equal(expectedModel[0].Text, result[0].Text);
            Assert.Equal(expectedModel[0].Value, result[0].Value);
        }
    }
}
