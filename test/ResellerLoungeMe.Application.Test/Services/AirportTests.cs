using Moq;
using ResellerLoungeMe.Application.Services;
using ResellerLoungeMe.Core.Interfaces;
using ResellerLoungeMe.Core.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ResellerLoungeMe.Application.Test
{
    public class AirportTests
    {

        private Mock<IAirportAdapter> _mockAirportAdapter;

        public AirportTests()
        {
            _mockAirportAdapter = new Mock<IAirportAdapter>();
        }
        [Fact]
        public void Get_Airport_Return_Null_If_NotFound()
        {
            var airportService = new AirportService(_mockAirportAdapter.Object);
            var airportData = airportService.GetAirportAsync(It.IsAny<int>());

            Assert.Null(airportData);
        }
    }
}
