using Microsoft.Extensions.Options;
using Moq;
using ResellerLoungeMe.Core;
using ResellerLoungeMe.Core.Configuration;
using ResellerLoungeMe.Core.Interfaces;
using ResellerLoungeMe.Infrastructure.Adapters;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ResellerLoungeMe.Infrastructure.Test.Adapters
{
    public class AirportTests
    {
        private Mock<IActionInvoker> _mockActionInvoker;
        private Mock<IOptions<LoungeMeServerSettings>> _settings;

        private readonly IAirportAdapter _airportAdapter;
        public AirportTests()
        {
            _mockActionInvoker = new Mock<IActionInvoker>();
            _settings = new Mock<IOptions<LoungeMeServerSettings>>();
            _airportAdapter = new AirportAdapter(_settings.Object, _mockActionInvoker.Object);
        }

        [Fact]
        public void GetAirports()
        {
        }
    }
}
