using Frags.Data.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frags.Services.ViewModels.Category
{
    public class CategoryFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
