using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Frags.Data.Data;
using Frags.Services.Interfaces;

namespace Frags.Controllers
{
    public class ShopController : Controller
    {
        private readonly FragsDbContext _context;
        private readonly IFragranceService fragranceService;

        public ShopController(FragsDbContext context, IFragranceService fragranceService)
        {
            _context = context;
            this.fragranceService = fragranceService;
        }

        public async Task<IActionResult> Index(
        string search,
        int? brandId,
        int? categoryId,
        string gender,
        string sort,
        int page = 1)
        {
            int pageSize = 8;
            var result = await fragranceService.FragranceFilterAsync(search, brandId, categoryId, gender, sort, page);
            ViewBag.TotalItems = result.TotalItems;

            ViewBag.Brands = await _context.Brands.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)result.TotalItems / pageSize);

            return View(result.Fragrances);
        }

        public async Task<IActionResult> Details(int id)
        {
            var fragrance = await fragranceService.GetByIdAsync(id);

            if (fragrance == null)
            {
                return NotFound();
            }

            return View(fragrance);
        }
    }
}
