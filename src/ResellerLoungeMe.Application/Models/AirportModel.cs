using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ResellerLoungeMe.Application.Models
{
    public class AirportModel : BaseModel
    {
        public string City { get; set; }
        public ICollection<TerminalModel> Terminals { get; set; }
        public ICollection<SelectListItem> SelectListTerminals { get; set; }
    }
}
