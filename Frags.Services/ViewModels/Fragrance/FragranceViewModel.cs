using Frags.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace Frags.Services.ViewModels.Fragrance
{
    public class FragranceViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.FragranceNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.01", "10000")]
        public decimal? Price { get; set; }

        [Required]
        [MaxLength(2048)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.FragranceDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Display(Name = "Brand")]
        [Required]
        public string Brand { get; set; } = string.Empty;

        public int? BrandId { get; set; }

        [Display(Name = "Category")]
        [Required]
        public string Category { get; set; } = string.Empty;

        public int? CategoryId { get; set; }

        [Required]
        public string Gender { get; set; } = null!;
    }
}
