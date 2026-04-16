using Frags.Data.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frags.Data.Models
{
    public class Fragrance
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.FragranceNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(ValidationConstants.FragrancePriceMin, ValidationConstants.FragrancePriceMax)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.FragranceDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public int BrandId { get; set; }

        public Brand? Brand { get; set; }
    }
}
