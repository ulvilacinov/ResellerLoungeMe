namespace ResellerLoungeMe.Models.API.Lounge
{
    public class LoungeRateInfoDto
    {
        public decimal AverageRate { get; set; }
        public int DistinctUserRateCount { get; set; }
        public int RateCount { get; set; }
    }
}