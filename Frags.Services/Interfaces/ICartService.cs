using Frags.Data.Models;

namespace Frags.Services.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(int fragranceId, string sessionId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(string sessionId);
        Task RemoveAsync(int id);
        Task<decimal> GetTotalAsync(string sessionId);
        Task<int> GetCartCountAsync(string sessionId);
        Task IncreaseAsync(int id);
        Task DecreaseAsync(int id);
    }
}
