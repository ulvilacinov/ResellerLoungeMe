using System.Collections.Generic;

namespace ResellerLoungeMe.Core.Models.Lounge
{
    public class LoungeGroupDto : NameDto
    {
        public ICollection<int> LoungeIds { get; set; }
        public ICollection<LoungeDto> Lounges { get; set; }
    }
}