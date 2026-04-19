using Frags.Services.Interfaces;
using Frags.Services.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frags.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageCategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public ManageCategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryFormModel category)
        {
            if (!ModelState.IsValid)
                return View(category);

            await categoryService.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryFormModel category)
        {
            if (!ModelState.IsValid) 
                return View(category);

            await categoryService.EditAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}