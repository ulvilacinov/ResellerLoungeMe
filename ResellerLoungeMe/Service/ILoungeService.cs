using ResellerLoungeMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Service
{
    public interface ILoungeService
    {
        LoungeViewModel GetLounge(int id);
    }
}
