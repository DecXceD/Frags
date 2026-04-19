using Frags.Data.Validation;
using Frags.Services.ViewModels.Fragrance;
using System.ComponentModel.DataAnnotations;
namespace Frags.Services.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<FragranceViewModel> Fragrances { get; set; } = new List<FragranceViewModel>();
    }
}
