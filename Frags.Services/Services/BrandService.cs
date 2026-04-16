using Frags.Data.Data;
using Frags.Data.Models;
using Frags.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frags.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly FragsDbContext context;

        public BrandService(FragsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
            => await context.Brands.ToListAsync();

        public async Task<Brand?> GetByIdAsync(int id)
            => await context.Brands
                .Include(b => b.Fragrances)
                .FirstOrDefaultAsync(b => b.Id == id);
    }
}
