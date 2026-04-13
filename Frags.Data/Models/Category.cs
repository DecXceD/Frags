using Frags.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace Frags.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Fragrance> Fragrances { get; set; } = new List<Fragrance>();
    }
}
