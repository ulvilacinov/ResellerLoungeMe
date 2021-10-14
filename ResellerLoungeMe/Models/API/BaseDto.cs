using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Models.API
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
