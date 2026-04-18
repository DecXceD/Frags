using Frags.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Frags.Controllers
{
    public class BrandsController : Controller
    {
        private readonly FragsDbContext context;

        public BrandsController(FragsDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await context.Brands.ToListAsync();
            return View(brands);
        }

        public async Task<IActionResult> Details(int id)
        {
            var brand = await context.Brands
                .Include(b => b.Fragrances)
                .ThenInclude(f => f.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null) return NotFound();

            return View(brand);
        }
    }
}
