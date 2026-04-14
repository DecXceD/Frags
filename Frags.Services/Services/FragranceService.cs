using Frags.Data.Data;
using Frags.Data.Models;
using Frags.Services.Interfaces;
using Frags.ViewModels.Fragrance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frags.Services.Services
{
    public class FragranceService : IFragranceService
    {
        private readonly FragsDbContext context;

        public FragranceService(FragsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Fragrance>> GetAllAsync()
            => await context.Fragrances
                .Include(f => f.Category)
                .ToListAsync();

        public async Task<Fragrance?> GetByIdAsync(int id)
            => await context.Fragrances
                .Include(f => f.Category)
                .FirstOrDefaultAsync(f => f.Id == id);

        public async Task CreateAsync(FragranceFormModel model)
        {
            var fragrance = new Fragrance
            {
                Name = model.Name,
                Price = model.Price!.Value,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Gender = model.Gender,
                CategoryId = model.CategoryId!.Value
            };

            await context.Fragrances.AddAsync(fragrance);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, FragranceFormModel model)
        {
            var fragrance = await context.Fragrances.FindAsync(id);

            if (fragrance == null)
                return;

            fragrance.Name = model.Name;
            fragrance.Price = model.Price!.Value;
            fragrance.ImageUrl = model.ImageUrl;
            fragrance.Description = model.Description;
            fragrance.Gender = model.Gender;
            fragrance.CategoryId = model.CategoryId!.Value;

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fragrance = await context.Fragrances.FindAsync(id);

            if (fragrance != null)
            {
                context.Fragrances.Remove(fragrance);
                await context.SaveChangesAsync();
            }
        }

        public async Task<FragranceFormModel?> GetForEditAsync(int id)
        {
            var fragrance = await context.Fragrances.FindAsync(id);

            if (fragrance == null)
                return null;

            return new FragranceFormModel
            {
                Id = fragrance.Id,
                Name = fragrance.Name,
                Price = fragrance.Price,
                ImageUrl = fragrance.ImageUrl,
                Description = fragrance.Description,
                Gender = fragrance.Gender,
                CategoryId = fragrance.CategoryId,
                Categories = await context.Categories.ToListAsync()
            };
        }
    }
}
