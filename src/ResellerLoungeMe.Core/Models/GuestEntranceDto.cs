using System;

namespace ResellerLoungeMe.Core.Models
{
    public class GuestEntranceDto : BaseDto
    {
        public int ChildCount { get; set; }
        public DateTime EntranceDate { get; set; }
        //public UserPaymentDto Payment { get; set; }
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public string Pnr { get; set; }
        public string State { get; set; }
        public string Type{ get; set; }
        public int UserTicketId { get; set; }
    }
}