using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Models
{
    public class AirportViewModel : BaseViewModel
    {
        public string City { get; set; }
        public ICollection<TerminalViewModel> Terminals { get; set; }
        public ICollection<SelectListItem> SelectListTerminals { get; set; }
    }
}
