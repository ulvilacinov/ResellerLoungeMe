namespace ResellerLoungeMe.Core.Models.Reseller
{
    public class ResellerDto : BaseDto
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
    }
}