using System;

namespace ResellerLoungeMe.Models.API
{
    public class LoungeClosedSeasonDto : BaseDto
    {
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionEs { get; set; }
        public string DescriptionTr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LoungeId { get; set; }
        public bool IgnoreYear { get; set; }
    }
}