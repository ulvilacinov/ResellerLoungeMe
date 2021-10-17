using ResellerLoungeMe.Models.API.Lounge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Data.APIs.Adapters
{
    public interface ILoungeAdapter
    {
        LoungeDto GetLounge(int id);
    }
}
