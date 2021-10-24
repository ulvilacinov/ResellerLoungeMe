using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ResellerLoungeMe.Application.Models
{
    public class AirportModel : BaseModel
    {
        public string City { get; set; }
        public IList<TerminalModel> Terminals { get; set; }
        public IList<SelectListItem> SelectListTerminals { get; set; }
    }
}
