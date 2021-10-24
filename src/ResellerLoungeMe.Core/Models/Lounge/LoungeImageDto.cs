namespace ResellerLoungeMe.Core.Models.Lounge
{
    public class LoungeImageDto : BaseDto
    {
        public int LoungeId { get; set; }
        public string OrderIndex { get; set; }
        public string Url { get; set; }
    }
}