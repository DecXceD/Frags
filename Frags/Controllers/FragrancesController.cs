using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Frags.Data;
using Frags.Models;

namespace Frags.Controllers
{
    public class FragrancesController : Controller
    {
        private readonly FragsDbContext _context;

        public FragrancesController(FragsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var fragsDbContext = _context.Fragrances.Include(f => f.Category);
            return View(await fragsDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fragrances == null)
            {
                return NotFound();
            }

            var fragrance = await _context.Fragrances
                .Include(f => f.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fragrance == null)
            {
                return NotFound();
            }

            return View(fragrance);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,ImageUrl,Description,Gender,CategoryId")] Fragrance fragrance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fragrance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", fragrance.CategoryId);
            return View(fragrance);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fragrances == null)
            {
                return NotFound();
            }

            var fragrance = await _context.Fragrances.FindAsync(id);
            if (fragrance == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", fragrance.CategoryId);
            return View(fragrance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,ImageUrl,Description,Gender,CategoryId")] Fragrance fragrance)
        {
            if (id != fragrance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fragrance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FragranceExists(fragrance.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", fragrance.CategoryId);
            return View(fragrance);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fragrances == null)
            {
                return NotFound();
            }

            var fragrance = await _context.Fragrances
                .Include(f => f.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.Fragrances == null)
            {
                return Problem("Entity set 'FragsDbContext.Fragrances'  is null.");
            }
            var fragrance = await _context.Fragrances.FindAsync(id);
            if (fragrance != null)
            {
                _context.Fragrances.Remove(fragrance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FragranceExists(int id)
        {
          return (_context.Fragrances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
