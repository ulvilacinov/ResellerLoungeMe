using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using ResellerLoungeMe.Data.APIs.Adapters;
using ResellerLoungeMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Service
{
    public class AirportService : IAirportService
    {
        private readonly IAirportAdapter _airportAdapter;
        private readonly IMemoryCache _cache;


        public AirportService(IAirportAdapter airportAdapter,IMemoryCache cache)
        {
            _airportAdapter = airportAdapter;
            _cache = cache;
        }

        public AirportViewModel GetAirport(int id)
        {
            var data = _airportAdapter.GetAirport(id);
            AirportViewModel result = new AirportViewModel
            {
                City = data.City?.Name,
                Name = data.Name,
                Id = data.Id,
                SelectListTerminals = data.Terminals?.Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() }).ToList(),
                Terminals = data.Terminals.Select(t => new TerminalViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Lounges = t.Lounges.Select(l => new LoungeViewModel
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Price = l.Price,
                        Images = l.Images.Select(i => new ImageViewModel { Url = i.Url, OrderIndex = i.OrderIndex }).ToList()
                    }).ToList()
                }).ToList()
            };

            return result;

        }

        public List<SelectListItem> GetAirports(string searchKey)
        {
            List<SelectListItem> airportSelectList = _airportAdapter.GetAirports(searchKey).Select(item => new SelectListItem
            {
                Text = $"{item.City.Name} | {item.Name}",
                Value = item.Id.ToString()
            }).ToList();
            return airportSelectList;
        }

        public void GetAndSetAirportsCache()
        {
            List<SelectListItem> airportSelectList = new List<SelectListItem>();

            if (!_cache.TryGetValue("Airports", out airportSelectList))
            {
                airportSelectList = _airportAdapter.GetAirports("").Select(item => new SelectListItem
                {
                    Text = $"{item.City.Name} | {item.Name}",
                    Value = item.Id.ToString()
                }).ToList();

                _cache.Set("Airports", airportSelectList, TimeSpan.FromDays(1));
            }
        }
    }
}
