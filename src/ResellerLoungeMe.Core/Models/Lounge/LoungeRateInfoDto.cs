namespace ResellerLoungeMe.Core.Models.Lounge
{
    public class LoungeRateInfoDto
    {
        public decimal AverageRate { get; set; }
        public int DistinctUserRateCount { get; set; }
        public int RateCount { get; set; }
    }
}