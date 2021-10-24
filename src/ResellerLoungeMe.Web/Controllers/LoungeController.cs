using Microsoft.AspNetCore.Mvc;
using ResellerLoungeMe.Application.Interfaces;
using System.Threading.Tasks;

namespace ResellerLoungeMe.Controllers
{
    public class LoungeController : Controller
    {
        private readonly ILoungeService _service;

        public LoungeController(ILoungeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int id)
        {
            var result = await _service.GetLoungeAsync(id);

            return View(result);
        }
    }
}
