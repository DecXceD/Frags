using Frags.Data.Models;
using Frags.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace Frags.ViewModels.Fragrance
{
    public class FragranceFormModel
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
        public int? BrandId { get; set; }

        public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();


        [Display(Name = "Category")]
        [Required]
        public int? CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public string Gender { get; set; } = null!;
    }
}
