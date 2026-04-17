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

        public async Task AddToCartAsync(int fragranceId, string sessionId)
        {
            var existing = await context.CartItems
                .FirstOrDefaultAsync(c => c.FragranceId == fragranceId && c.SessionId == sessionId);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                var item = new CartItem
                {
                    FragranceId = fragranceId,
                    Quantity = 1,
                    SessionId = sessionId
                };

                await context.CartItems.AddAsync(item);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync(string sessionId)
            => await context.CartItems
                .Include(c => c.Fragrance)
                .ThenInclude(f => f.Brand)
                .Where(c => c.SessionId == sessionId)
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

        public async Task<decimal> GetTotalAsync(string sessionId)
        {
            var items = await context.CartItems
                .Include(c => c.Fragrance)
                .Where(c => c.SessionId == sessionId)
                .ToListAsync();

            return items.Sum(i => i.Fragrance.Price * i.Quantity);
        }

        public async Task<int> GetCartCountAsync(string sessionId)
        {
            return await context.CartItems
                .Where(c => c.SessionId == sessionId)
                .SumAsync(c => c.Quantity);
        }

        public async Task IncreaseAsync(int id)
        {
            var item = await context.CartItems.FindAsync(id);

            if (item != null)
            {
                item.Quantity++;
                await context.SaveChangesAsync();
            }
        }

        public async Task DecreaseAsync(int id)
        {
            var item = await context.CartItems.FindAsync(id);

            if (item == null)
                return;

            item.Quantity--;

            if (item.Quantity <= 0)
            {
                context.CartItems.Remove(item);
            }

            await context.SaveChangesAsync();
        }
    }
}
