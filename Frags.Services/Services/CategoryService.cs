using Frags.Data.Data;
using Frags.Data.Models;
using Frags.Services.Interfaces;
using Frags.Services.ViewModels.Brand;
using Frags.Services.ViewModels.Category;
using Frags.Services.ViewModels.Fragrance;
using Microsoft.EntityFrameworkCore;

namespace Frags.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FragsDbContext context;

        public CategoryService(FragsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategoryFormModel>> GetAllAsync()
        {
            return await context.Categories
                .Select(c => new CategoryFormModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<CategoryFormModel?> GetByIdAsync(int id)
            => await context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryFormModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefaultAsync();

        public async Task<CategoryViewModel?> GetViewByIdAsync(int id)
            => await context.Categories
                .Where(c => c.Id == id)
                .Include(c => c.Fragrances)
                    .ThenInclude(f => f.Brand)
                .Include(c => c.Fragrances)
                    .ThenInclude(f => f.Category)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Fragrances = c.Fragrances.Select(f => new FragranceViewModel
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Price = f.Price,
                        ImageUrl = f.ImageUrl,
                        Description = f.Description,
                        Brand = f.Brand!.Name,
                        Category = f.Category!.Name,
                        Gender = f.Gender
                    }).ToList()
                })
                .FirstOrDefaultAsync();

        public async Task CreateAsync(CategoryFormModel category)
        {
            var entity = new Category
            {
                Name = category.Name
            };

            await context.Categories.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(CategoryFormModel category)
        {
            var entity = await context.Categories.FindAsync(category.Id);

            if (entity == null)
            {
                throw new ArgumentException("Category not found.");
            }

            entity.Name = category.Name;
            context.Categories.Update(entity);
            await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);

            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
        }
    }
}
