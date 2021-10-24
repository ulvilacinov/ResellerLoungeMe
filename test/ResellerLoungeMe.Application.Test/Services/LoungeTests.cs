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

namespace ResellerLoungeMe.Application.Test.Services
{
    public class LoungeTests
    {
        private Mock<ILoungeAdapter> _mockLoungeAdapter;
        private readonly ILoungeService _loungeService;

        public LoungeTests()
        {
            _mockLoungeAdapter = new Mock<ILoungeAdapter>();
            _loungeService = new LoungeService(_mockLoungeAdapter.Object);
        }

        [Fact]
        public void GetLounge_Should_Return_Correct_Result_ById()
        {
            LoungeModel loungeModel = CreateLoungeModel();

            LoungeDto loungeDto = CreateLoungeDto();

            _mockLoungeAdapter.Setup(w => w.GetLoungeAsync(1)).Returns(Task.FromResult(loungeDto));

            var result = _loungeService.GetLoungeAsync(1).Result;

            Assert.Equal(loungeModel.Id, result.Id);
            Assert.Equal(loungeModel.Name, result.Name);
            Assert.Equal(loungeModel.Price, result.Price);
            Assert.Equal(loungeModel.ChildPolicy, result.ChildPolicy);
            Assert.Equal(loungeModel.City, result.City);
            Assert.Equal(loungeModel.Airport, result.Airport);
            Assert.Equal(loungeModel.Country, result.Country);
            Assert.Equal(loungeModel.Direction, result.Direction);
            Assert.Equal(loungeModel.LocationDescription, result.LocationDescription);
            Assert.Equal(loungeModel.Terminal, result.Terminal);
            Assert.Equal(loungeModel.UsageHourLimit, result.UsageHourLimit);
            Assert.Equal(loungeModel.Amenties[0], result.Amenties[0]);
            Assert.Equal(loungeModel.Features[0], result.Features[0]);
            Assert.Equal(loungeModel.ClosedSeasons[0].Description, result.ClosedSeasons[0].Description);
            Assert.Equal(loungeModel.ClosedSeasons[0].EndDate, result.ClosedSeasons[0].EndDate);
            Assert.Equal(loungeModel.ClosedSeasons[0].StartDate, result.ClosedSeasons[0].StartDate);
            Assert.Equal(loungeModel.OpenHours[0].BeginHour, result.OpenHours[0].BeginHour);
            Assert.Equal(loungeModel.OpenHours[0].EndHour, result.OpenHours[0].EndHour);
            Assert.Equal(loungeModel.OpenHours[0].Day, result.OpenHours[0].Day);
            Assert.Equal(loungeModel.Images[0].OrderIndex, result.Images[0].OrderIndex);
            Assert.Equal(loungeModel.Images[0].Url, result.Images[0].Url);

        }

        private LoungeDto CreateLoungeDto()
        {
            return new LoungeDto
            {
                Id = 1,
                Name = "Salam Lounge",
                Price = 23,
                ChildPolicy = "2",
                Direction = "DEPARTURE",
                LocationDescription = "Location Description",
                UsageHourLimit = "3",
                Terminal = new TerminalDto
                {
                    Name = "Terminal 1",
                    Airport = new AirportDto
                    {
                        Name = "Heydar Aliyev Airport",
                        City = new CityDto
                        {
                            Name = "Baku",
                            Country = new CountryDto
                            {
                                Name = "Azerbaijan"
                            }
                        },
                    },
                },
                OpenHours = new List<LoungeOpenHourDto> { new LoungeOpenHourDto { BeginHour = "08:00:00", EndHour = "00:00:00", Day = "Sunday" } },
                ClosedSeasons = new List<LoungeClosedSeasonDto>
                {
                    new LoungeClosedSeasonDto { StartDate = DateTime.MinValue, EndDate = DateTime.MaxValue, Description = "Closed" },
                },
                Features = new List<LoungeFeatureDto> {
                    new LoungeFeatureDto { Feature = new FeatureDto { Name = "newspaper & magazine", Type = "FEATURE" }, },
                    new LoungeFeatureDto { Feature = new FeatureDto { Name = "shower", Type = "EXTRA_FEATURE" }, }
                },
                Images = new List<LoungeImageDto> { new LoungeImageDto { OrderIndex = "1", Url = "path" } }
            };
        }

        private LoungeModel CreateLoungeModel()
        {
            return new LoungeModel
            {
                Id = 1,
                Name = "Salam Lounge",
                Price = 23,
                ChildPolicy = "2",
                City = "Baku",
                Airport = "Heydar Aliyev Airport",
                Country = "Azerbaijan",
                Direction = "DEPARTURE",
                LocationDescription = "Location Description",
                Terminal = "Terminal 1",
                UsageHourLimit = "3",
                Amenties = new List<string> { "shower" },
                Features = new List<string> { "newspaper & magazine" },
                ClosedSeasons = new List<ClosedSeasonsModel> { new ClosedSeasonsModel { StartDate = DateTime.MinValue, EndDate = DateTime.MaxValue, Description = "Closed" } },
                OpenHours = new List<OpenHoursModel>() {
                    new OpenHoursModel { BeginHour = "08:00:00", EndHour = "00:00:00", Day = "Sunday" },
                },
                Images = new List<ImageModel> { new ImageModel { OrderIndex = "1", Url = "path" } }
            };
        }


    }
}
