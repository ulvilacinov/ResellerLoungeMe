using ResellerLoungeMe.Models.API.Lounge;
using System;

namespace ResellerLoungeMe.Models.API.User
{
    public class UserDto : BaseDto
    {
        public int ActiveTicketCount { get; set; }
        //public UserAddressDto Address { get; set; }
        public DateTime Birthday{ get; set; }
        public CountryDto Country { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public DateTime emailValidationDate { get; set; }
        public string FacebookId { get; set; }
        public string Gender { get; set; }
        public bool HasAddedAnyCards { get; set; }
        public string ImageUrl { get; set; }
        public string LastLanguageCode { get; set; }
        public string Name { get; set; }
        //public UserPassivationDto Passivation { get; set; }
        public string PassportNo { get; set; }
        public string Phone { get; set; }
        public int PhonePrefixLength { get; set; }
        public bool RewardHanded { get; set; }
        public string SelectedCurrency { get; set; }
        public string SignupChannel { get; set; }
        //public InvitationDto SignupInvitation { get; set; }
        public LoungeDto SignupLounge { get; set; }
        public int SignupLoungeId { get; set; }
        public int SignupUserId { get; set; }
        public string Surname { get; set; }
        public int UsablePoints { get; set; }
        public bool UserInfoCompleted { get; set; }
        //public UserMembershipDto UserMembership { get; set; }
        //public UserRoleDto UserRole { get; set; }
        public string Username { get; set; }
    }
}