using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Models
{
    public class TerminalModel : BaseModel
    {
        public ICollection<LoungeModel> Lounges { get; set; }
    }
}
