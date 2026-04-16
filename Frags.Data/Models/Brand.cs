using Frags.Data.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frags.Data.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.BrandNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Fragrance> Fragrances { get; set; } = new List<Fragrance>();
    }
}
