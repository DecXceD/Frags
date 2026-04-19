using Frags.Data.Data;
using Frags.Data.Models;
using Frags.Services.Interfaces;
using Frags.Services.Services;
using Frags.Services.ViewModels.Fragrance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frags.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageFragrancesController : Controller
    {
        private readonly IFragranceService fragranceService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;

        public ManageFragrancesController(IFragranceService fragranceService, ICategoryService categoryService, IBrandService brandService)
        {
            this.fragranceService = fragranceService;
            this.categoryService = categoryService;
            this.brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var fragrances = await fragranceService.GetAllAsync();
            return View(fragrances);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fragrance = await fragranceService.GetByIdAsync(id.Value);

            if (fragrance == null)
            {
                return NotFound();
            }

            return View(fragrance);
        }

        public async Task<IActionResult> Create()
        {
            var model = new FragranceFormModel
            {
                Categories = await categoryService.GetAllAsync(),
                Brands = await brandService.GetAllAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FragranceFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllAsync();
                return View(model);
            }

            await fragranceService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await fragranceService.GetForEditAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FragranceFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllAsync();
                return View(model);
            }

            await fragranceService.UpdateAsync(id, model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fragrance = await fragranceService.GetByIdAsync(id.Value);

            if (fragrance == null)
            {
                return NotFound();
            }

            return View(fragrance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await fragranceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
