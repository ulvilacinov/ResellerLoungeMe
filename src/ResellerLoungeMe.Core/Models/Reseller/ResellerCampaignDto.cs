using System;
using System.Collections;
using System.Collections.Generic;

namespace ResellerLoungeMe.Core.Models.Reseller
{
    public class ResellerCampaignDto : BaseDto
    {
        public DateTime ActivationDate { get; set; }
        public bool Active { get; set; }
        public string CancellationPolicyEn { get; set; }
        public string CancellationPolicyEs { get; set; }
        public string CancellationPolicyTr { get; set; }
        public string ContractDetail { get; set; }
        public DateTime EndDate { get; set; }
        //public ICollection<ResellerCampaignLoungeGroupDto> LoungeGroups { get; set; }
        public string Name { get; set; }
        public ResellerDto ResellerDto { get; set; }
        public int ResellerId { get; set; }
        public string Status { get; set; }
    }
}