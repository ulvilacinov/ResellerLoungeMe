﻿using System.Collections.Generic;

namespace ResellerLoungeMe.Models.API.Ticket
{
    public class LoungeGroupDto : NameDto
    {
        public ICollection<int> LoungeIds { get; set; }
        public ICollection<LoungeDto> Lounges { get; set; }
    }
}