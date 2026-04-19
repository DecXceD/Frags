using Frags.Services.ViewModels.Category;

namespace Frags.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryFormModel>> GetAllAsync();
        Task<CategoryFormModel?> GetByIdAsync(int id);
        Task<CategoryViewModel?> GetViewByIdAsync(int id);
        Task CreateAsync(CategoryFormModel category);
        Task EditAsync(CategoryFormModel category);
        Task DeleteAsync(int id);
    }
}
