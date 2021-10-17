using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Models
{
    public class TerminalViewModel : BaseViewModel
    {
        public ICollection<LoungeViewModel> Lounges { get; set; }
    }
}
