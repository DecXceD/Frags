using Frags.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Frags.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly FragsDbContext context;

        public CategoriesController(FragsDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await context.Categories.ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await context.Categories
                .Include(c => c.Fragrances)
                .ThenInclude(f => f.Brand)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();

            return View(category);
        }
    }
}
