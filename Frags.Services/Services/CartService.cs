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
    public class CartService : ICartService
    {
        private readonly FragsDbContext context;

        public CartService(FragsDbContext context)
        {
            this.context = context;
        }

        public async Task AddToCartAsync(int fragranceId, string userId)
        {
            var existing = await context.CartItems
                .FirstOrDefaultAsync(c => c.FragranceId == fragranceId && c.UserId == userId);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                await context.CartItems.AddAsync(new CartItem
                {
                    FragranceId = fragranceId,
                    UserId = userId,
                    Quantity = 1
                });
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItem>> GetUserCartAsync(string userId)
            => await context.CartItems
                .Include(c => c.Fragrance)
                .ThenInclude(f => f.Brand)
                .ToListAsync();

        public async Task RemoveAsync(int id)
        {
            var item = await context.CartItems.FindAsync(id);

            if (item != null)
            {
                context.CartItems.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
