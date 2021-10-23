using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Models
{
    public abstract class NameDto : BaseDto
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string NameEs { get; set; }
        public string NameTr { get; set; }
    }
}
