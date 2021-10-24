using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Models
{
    public class TimeDto
    {
        public int Date { get; set; }
        public int Day { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Month { get; set; }
        public int Seconds { get; set; }
        public int Time { get; set; }
        public int TimeZoneOffset { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }
    }
}
