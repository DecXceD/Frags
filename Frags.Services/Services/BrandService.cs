using Frags.Data.Data;
using Frags.Data.Models;
using Frags.Services.Interfaces;
using Frags.Services.ViewModels.Brand;
using Microsoft.EntityFrameworkCore;

namespace Frags.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly FragsDbContext context;

        public BrandService(FragsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<BrandFormModel>> GetAllAsync()
            => await context.Brands
                .Select(b => new BrandFormModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToListAsync();

        public async Task<BrandFormModel?> GetByIdAsync(int id)
            => await context.Brands
                .Where(b => b.Id == id)
                .Select(b => new BrandFormModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .FirstOrDefaultAsync();

        public async Task CreateAsync(BrandFormModel brand)
        {
            var entity = new Brand
            {
                Name = brand.Name
            };

            await context.Brands.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(BrandFormModel brand)
        {
            var entity = await context.Brands.FindAsync(brand.Id);

            if (entity == null)
            {
                throw new ArgumentException("Brand not found.");
            }

            entity.Name = brand.Name;

            context.Brands.Update(entity);
            await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var brand = await context.Brands.FindAsync(id);

            if (brand != null)
            {
                context.Brands.Remove(brand);
                await context.SaveChangesAsync();
            }
        }
    }
}
