using Frags.Data.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frags.Services.ViewModels.Brand
{
    public class BrandFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.BrandNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
