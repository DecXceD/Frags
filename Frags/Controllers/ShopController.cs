using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Frags.Data.Data;

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

        public async Task<IActionResult> Details(int id)
        {
            var fragrance = await _context.Fragrances
                .Include(f => f.Category)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (fragrance == null)
            {
                return NotFound();
            }

            return View(fragrance);
        }
    }
}
