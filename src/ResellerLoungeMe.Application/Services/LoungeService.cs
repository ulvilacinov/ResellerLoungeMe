using ResellerLoungeMe.Application.Interfaces;
using ResellerLoungeMe.Application.Models;
using ResellerLoungeMe.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Services
{
    public class LoungeService : ILoungeService
    {
        private readonly ILoungeAdapter _loungeAdapter;

        public LoungeService(ILoungeAdapter loungeAdapter)
        {
            _loungeAdapter = loungeAdapter;
        }

        public async Task<LoungeModel> GetLoungeAsync(int id)
        {
            var data = await _loungeAdapter.GetLoungeAsync(id);
            LoungeModel result = new LoungeModel
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
                ClosedSeasons = data.ClosedSeasons?.Select(c => new ClosedSeasonsModel
                {
                    Description = c.Description,
                    EndDate = c.EndDate,
                    StartDate = c.StartDate
                }).ToArray(),
                OpenHours = data.OpenHours?.Select(o => new OpenHoursModel
                {
                    BeginHour = o.BeginHour,
                    Day = o.Day,
                    EndHour = o.EndHour
                }).ToArray(),
                Amenties = data.Features?.Where(w => w.Feature.Type == "EXTRA_FEATURE").Select(s => s.Feature.Name).ToArray(),
                Features = data.Features?.Where(w => w.Feature.Type == "FEATURE").Select(s => s.Feature.Name).ToArray(),
                Images = data.Images?.Select(i => new ImageModel
                {
                    Url = i.Url,
                    OrderIndex = i.OrderIndex
                }).ToArray()
            };

            return result;
        }
    }
}
