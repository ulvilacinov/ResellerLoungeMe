using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Models
{
    public class TerminalModel : BaseModel
    {
        public IList<LoungeModel> Lounges { get; set; }
    }
}
