using ResellerLoungeMe.Core.Models.Lounge;
using ResellerLoungeMe.Core.Models.Reseller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Models.User
{
    public class UserTicketDto : BaseDto
    {
        public string AffiliateId { get; set; }
        public DateTime CancellationDate{ get; set; }
        public string CancellationReason { get; set; }  
        public string CancellationType { get; set; }
        public int ChildCount { get; set; }
        public string CreationType { get; set; }
        public string CurrencyType { get; set; }
        public string EntranceRoleType { get; set; }
        public string EntranceType { get; set; }
        public UserDto EntranceUser { get; set; }
        public int EntranceUserId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ICollection<GuestEntranceDto> GuestEntrances { get; set; }
        public LoungeDto Lounge{ get; set; }
        public int LoungeId { get; set; }
        //public UserPaymentDto Payment { get; set; }
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public string Pnr { get; set; }
       // public UserTicketRateDto Rate { get; set; }
        public bool Rated { get; set; }
        public ResellerCampaignDto ResellerCampaign { get; set; }
        public int ResellerCampaignId { get; set; }
        public int ResellerCampaignLoungeGroupId { get; set; }
        public decimal SoldPrice { get; set; }
        public string State { get; set; }
        public string usageDate { get; set; }
        public UserDto User { get; set; }
        public int UserId { get; set; }
        //public UserMembershipDto UserMembership { get; set; }
        public int UserMembershipId { get; set; }
    }
}
