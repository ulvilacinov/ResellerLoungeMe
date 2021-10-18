using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Models.API
{
    public class ResultTicketDto : BaseDto
    {
        public int UserId { get; set; }
        public int LoungeId { get; set; }
        public string CurrencyType { get; set; }
        public int ResellerCampaignId { get; set; }
        public int ResellerCampaignLoungeGroupId { get; set; }
        public string CreationType { get; set; }
        public int ChildCount { get; set; }
        public string PaymentType { get; set; }
        public string Pnr { get; set; }
        public string EntranceRoleType { get; set; }
        public string State { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal SoldPrice { get; set; }
        public ICollection<GuestEntranceDto> GuestEntrances { get; set; }

    }
}
