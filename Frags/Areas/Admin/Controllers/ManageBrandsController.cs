using Frags.Services.Interfaces;
using Frags.Services.ViewModels.Brand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frags.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageBrandsController : Controller
    {
        private readonly IBrandService brandService;

        public ManageBrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await brandService.GetAllAsync();
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandFormModel brand)
        {
            if (!ModelState.IsValid)
                return View(brand);

            await brandService.CreateAsync(brand);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand = await brandService.GetByIdAsync(id);
            if (brand == null) return NotFound();

            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandFormModel brand)
        {
            if (!ModelState.IsValid) 
                return View(brand);

            await brandService.EditAsync(brand);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await brandService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}