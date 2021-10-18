using ResellerLoungeMe.Data.APIs.Adapters;
using ResellerLoungeMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Service
{
    public class LoungeService : ILoungeService
    {
        private readonly ILoungeAdapter _loungeAdapter;

        public LoungeService(ILoungeAdapter loungeAdapter)
        {
            _loungeAdapter = loungeAdapter;
        }

        public LoungeViewModel GetLounge(int id)
        {
            var data = _loungeAdapter.GetLounge(id);
            LoungeViewModel result = new LoungeViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Price = data.Price,
                Airport = data.Terminal?.Airport?.Name,
                ChildPolicy = data.ChildPolicy,
                City = data.Terminal?.Airport?.City?.Name,
                Country = data.Terminal?.Airport?.City?.Country?.Name,
                Direction = data.Direction,
                LocationDescription = data.LocationDescription,
                UsageHourLimit = data.UsageHourLimit,
                Terminal = data.Terminal?.Name,
                ClosedSeasons = data.ClosedSeasons.Select(c => new ClosedSeasonsViewModel
                {
                    Description = c.Description,
                    EndDate = c.EndDate,
                    StartDate = c.StartDate
                }).ToArray(),
                OpenHours = data.OpenHours.Select(o => new OpenHoursViewModel
                {
                    BeginHour = o.BeginHour,
                    Day = o.Day,
                    EndHour = o.EndHour
                }).ToArray(),
                Amenties = data.Features.Where(w => w.Feature.Type == "EXTRA_FEATURE").Select(s => s.Feature.Name).ToArray(),
                Features = data.Features.Where(w => w.Feature.Type == "FEATURE").Select(s => s.Feature.Name).ToArray(),
                Images = data.Images.Select(i => new ImageViewModel
                {
                    Url = i.Url,
                    OrderIndex = i.OrderIndex
                }).ToArray()
            };

            return result;
        }
    }
}
