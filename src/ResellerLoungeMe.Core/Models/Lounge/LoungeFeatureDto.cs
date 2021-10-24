namespace ResellerLoungeMe.Core.Models.Lounge
{
    public class LoungeFeatureDto : BaseDto
    {
        public FeatureDto Feature { get; set; }
        public int FeatureId { get; set; }
        public string InformationText { get; set; }
        public string InformationTextEn { get; set; }
        public string InformationTextEs { get; set; }
        public string InformationTextTr { get; set; }
        public int LoungeId { get; set; }
    }
}