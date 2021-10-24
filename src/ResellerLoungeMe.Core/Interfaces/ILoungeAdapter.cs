using ResellerLoungeMe.Core.Models.Lounge;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Core.Interfaces
{
    public interface ILoungeAdapter
    {
        Task<LoungeDto> GetLoungeAsync(int id);
    }
}
