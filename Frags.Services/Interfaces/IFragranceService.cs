using Frags.Services.ViewModels.Fragrance;
using Frags.Data.Models;

namespace Frags.Services.Interfaces
{

    public interface IFragranceService
    {
        Task<IEnumerable<FragranceViewModel>> GetAllAsync();
        Task<FragranceViewModel?> GetByIdAsync(int id);
        Task CreateAsync(FragranceFormModel model);
        Task<FragranceFormModel?> GetForEditAsync(int id);
        Task UpdateAsync(int id, FragranceFormModel model);
        Task DeleteAsync(int id);
        Task<FragranceShopModel> FragranceFilterAsync(string search, int? brandId, int? categoryId, string gender, string sort, int page);
    }
}
