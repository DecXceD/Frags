using Frags.Data.Data;
using Frags.Data.Models;
using Frags.Services.Interfaces;
using Frags.Services.ViewModels.Fragrance;
using Microsoft.EntityFrameworkCore;

namespace Frags.Services.Services
{
    public class FragranceService : IFragranceService
    {
        private readonly FragsDbContext context;
        private readonly IBrandService brandService;
        private readonly ICategoryService categoryService;

        public FragranceService(FragsDbContext context, IBrandService brandService, ICategoryService categoryService)
        {
            this.context = context;
            this.brandService = brandService;
            this.categoryService = categoryService;
        }

        public async Task<IEnumerable<FragranceViewModel>> GetAllAsync()
            => await context.Fragrances
                .Include(f => f.Category)
                .Include(f => f.Brand)
                .Select(f => new FragranceViewModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    Price = f.Price,
                    ImageUrl = f.ImageUrl,
                    Description = f.Description,
                    Brand = f.Brand!.Name,
                    BrandId = f.BrandId,
                    Category = f.Category!.Name,
                    CategoryId = f.CategoryId,
                    Gender = f.Gender,
                }).ToListAsync();

        public async Task<FragranceViewModel?> GetByIdAsync(int id)
            => await context.Fragrances
                .Include(f => f.Category)
                .Include(f => f.Brand)
                .Select(f => new FragranceViewModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    Price = f.Price,
                    ImageUrl = f.ImageUrl,
                    Description = f.Description,
                    Brand = f.Brand!.Name,
                    BrandId = f.BrandId,
                    Category = f.Category!.Name,
                    CategoryId = f.CategoryId,
                    Gender = f.Gender,
                })
                .FirstOrDefaultAsync(f => f.Id == id);

        public async Task CreateAsync(FragranceFormModel model)
        {
            var fragrance = new Fragrance
            {
                Name = model.Name,
                Price = model.Price!.Value,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                BrandId = model.BrandId!.Value,
                CategoryId = model.CategoryId!.Value,
                Gender = model.Gender
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
            fragrance.BrandId = model.BrandId!.Value;
            fragrance.CategoryId = model.CategoryId!.Value;
            fragrance.Gender = model.Gender;
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
            var fragrance = await context.Fragrances
                .Include(f => f.Category)
                .Include(f => f.Brand)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (fragrance == null)
                return null;

            return new FragranceFormModel
            {
                Id = fragrance.Id,
                Name = fragrance.Name,
                Price = fragrance.Price,
                ImageUrl = fragrance.ImageUrl,
                Description = fragrance.Description,
                BrandId = fragrance.BrandId,
                Brands = await brandService.GetAllAsync(),
                CategoryId = fragrance.CategoryId,
                Categories = await categoryService.GetAllAsync(),
                Gender = fragrance.Gender
            };
        }
    }
}
