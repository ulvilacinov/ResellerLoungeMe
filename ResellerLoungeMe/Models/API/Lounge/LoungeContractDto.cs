using System;

namespace ResellerLoungeMe.Models.API
{
    public class LoungeContractDto : BaseDto
    {
        public bool Active { get; set; }
        public string ContractDetail { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public int EntranceCountBetweenContractDates { get; set; }
        public int LoungeId { get; set; }

    }
}