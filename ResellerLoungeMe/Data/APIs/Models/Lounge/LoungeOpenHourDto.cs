using System;

namespace ResellerLoungeMe.Models.API.Lounge
{
    public class LoungeOpenHourDto: BaseDto
    {
        public string BeginHour { get; set; }
        public string Day { get; set; }
        public string EndHour { get; set; }
        public int LoungeId { get; set; }
    }
}