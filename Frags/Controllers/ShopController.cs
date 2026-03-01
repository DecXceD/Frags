using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Frags.Data;

namespace Frags.Controllers
{
    public class ShopController : Controller
    {
        private readonly FragsDbContext _context;

        public ShopController(FragsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var fragrances = await _context.Fragrances
                .Include(f => f.Category)
                .ToListAsync();

            return View(fragrances);
        }
    }
}
