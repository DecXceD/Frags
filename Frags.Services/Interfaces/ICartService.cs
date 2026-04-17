using Frags.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frags.Services.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(int fragranceId, string userId);
        Task<IEnumerable<CartItem>> GetUserCartAsync(string userId);
        Task RemoveAsync(int id);
    }
}
