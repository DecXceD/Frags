using Frags.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frags.Services.Interfaces
{
    using Frags.Data.Models;
    using Frags.ViewModels.Fragrance;

    public interface IFragranceService
    {
        Task<IEnumerable<Fragrance>> GetAllAsync();
        Task<Fragrance?> GetByIdAsync(int id);

        Task CreateAsync(FragranceFormModel model);
        Task<FragranceFormModel?> GetForEditAsync(int id);
        Task UpdateAsync(int id, FragranceFormModel model);

        Task DeleteAsync(int id);
    }
}
