using System;

namespace ResellerLoungeMe.Models.API
{
    public class LoungeOpenHourDto: BaseDto
    {
        public DateTime BeginHour { get; set; }
        public string Day { get; set; }
        public DateTime EndHour { get; set; }
        public int LoungeId { get; set; }
    }
}