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

        public async Task<IActionResult> Index(
    string search,
    int? brandId,
    int? categoryId,
    string gender,
    int page = 1)
        {
            int pageSize = 8;

            var query = _context.Fragrances
                .Include(f => f.Brand)
                .Include(f => f.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(f => f.Name.Contains(search));
            }

            if (brandId.HasValue)
            {
                query = query.Where(f => f.BrandId == brandId);
            }

            if (categoryId.HasValue)
            {
                query = query.Where(f => f.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(f => f.Gender == gender);
            }

            int totalItems = await query.CountAsync();

            var fragrances = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.Brands = await _context.Brands.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            return View(fragrances);
        }

        public async Task<IActionResult> Details(int id)
        {
            var fragrance = await _context.Fragrances
                .Include(f => f.Brand)
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
