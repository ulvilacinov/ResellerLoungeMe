
using ResellerLoungeMe.Application.Interfaces;
using ResellerLoungeMe.Application.Models;
using ResellerLoungeMe.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportAdapter _airportAdapter;

        public AirportService(IAirportAdapter airportAdapter)
        {
            _airportAdapter = airportAdapter;
        }

        public async Task<AirportModel> GetAirportAsync(int id)
        {
            var data = await _airportAdapter.GetAirportAsync(id);

            AirportModel result = new AirportModel
            {
                City = data.City?.Name,
                Name = data.Name,
                Id = data.Id,
                SelectListTerminals = data.Terminals?.Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() }).ToArray(),
                Terminals = data.Terminals?.Select(t => new TerminalModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Lounges = t.Lounges?.Select(l => new LoungeModel
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Price = l.Price,
                        Images = l.Images?.Select(i => new ImageModel { Url = i.Url, OrderIndex = i.OrderIndex }).ToArray()
                    }).ToArray()
                }).ToArray()
            };

            return result;
        }

        public async Task<List<SelectListItem>> GetAirportsAsync(string searchKey)
        {
            var airportList = await _airportAdapter.GetAirportsAsync(searchKey);

            var airportSelectList = airportList.Select(item => new SelectListItem
            {
                Text = $"{item.City?.Name} | {item.Name}",
                Value = item.Id.ToString()
            }).ToList();

            return airportSelectList;
        }

    }
}
