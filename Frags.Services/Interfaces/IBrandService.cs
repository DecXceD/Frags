using Frags.Services.ViewModels.Brand;

namespace Frags.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandFormModel>> GetAllAsync();
        Task<BrandFormModel?> GetByIdAsync(int id);
        Task CreateAsync(BrandFormModel brand);
        Task EditAsync(BrandFormModel brand);
        Task DeleteAsync(int id);
    }
}
