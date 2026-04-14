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
    public class CategoryService : ICategoryService
    {
        private readonly FragsDbContext context;

        public CategoryService(FragsDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }
    }
}
