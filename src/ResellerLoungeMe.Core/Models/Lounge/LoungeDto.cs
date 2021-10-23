using System;
using System.Collections.Generic;

namespace ResellerLoungeMe.Core.Models.Lounge
{
    public class LoungeDto: BaseDto
    {
        public string ChildPolicy { get; set; }
        public ICollection<LoungeClosedSeasonDto> ClosedSeasons { get; set; }
        public string ContractDetail { get; set; }
        public DateTime ContractEndDate { get; set; }
        public DateTime ContractStartDate { get; set; }
        public ICollection<LoungeContractDto> Contracts { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionEs { get; set; }
        public string DescriptionTr { get; set; }
        public string Direction { get; set; }
        public bool EnteredOnce { get; set; }
        public int EntranceCountAfterContractStartDate { get; set; }
        public int EntranceCountOfLastMonth { get; set; }
        public int EntranceCountOverallTime { get; set; }
        public int FavouriteCount { get; set; }
        public bool Favourited { get; set; }
        public ICollection<LoungeFeatureDto> Features { get; set; }
        public bool HasAlreadyTicket { get; set; }
        public ICollection<LoungeImageDto> Images { get; set; }
        public string LocationDescription { get; set; }
        public string LocationDescriptionEn { get; set; }
        public string LocationDescriptionEs { get; set; }
        public string LocationDescriptionTr { get; set; }
        public LoungeOfficeDto LoungeOfficeDto { get; set; }
        public int LoungeOfficeId { get; set; }
        public string Name { get; set; }
        public ICollection<LoungeOpenHourDto> OpenHours { get; set; }
        public decimal OrderMultiplier { get; set; }
        public decimal OrderPoint { get; set; }
        public bool Passive { get; set; }
        public string PaymentStyle { get; set; }
        public decimal PointGainMultiplier { get; set; }
        public int PointToGain { get; set; }
        public string PostFix { get; set; }
        public decimal Price { get; set; }
        public LoungeRateInfoDto RateInfo { get; set; }
        public string Side { get; set; }
        public TerminalDto Terminal { get; set; }
        public int TerminalId { get; set; }
        public string UrlPostFix { get; set; }
        public string UsageHourLimit { get; set; }

    }
}