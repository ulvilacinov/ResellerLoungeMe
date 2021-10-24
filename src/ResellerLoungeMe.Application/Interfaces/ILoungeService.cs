using ResellerLoungeMe.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Application.Interfaces
{
    public interface ILoungeService
    {
        Task<LoungeModel> GetLoungeAsync(int id);
    }
}
