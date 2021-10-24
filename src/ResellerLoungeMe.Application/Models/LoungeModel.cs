using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Models
{
    public class LoungeModel : BaseModel
    {
        public string Terminal { get; set; }
        public string Airport { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Direction { get; set; }
        public string LocationDescription { get; set; }
        public string ChildPolicy { get; set; }
        public string UsageHourLimit { get; set; }
        public IList<ClosedSeasonsModel> ClosedSeasons { get; set; }
        public IList<OpenHoursModel> OpenHours { get; set; }
        public decimal Price { get; set; }
        public IList<ImageModel> Images { get; set; }
        public IList<string> Amenties { get; set; }
        public IList<string> Features { get; set; }
    }
}
