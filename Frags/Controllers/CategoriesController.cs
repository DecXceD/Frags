using Frags.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Frags.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllAsync();
            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await categoryService.GetViewByIdAsync(id);

            if (category == null) return NotFound();

            return View(category);
        }
    }
}
