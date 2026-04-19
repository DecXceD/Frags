using Frags.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace Frags.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ContactEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.ContactPhoneMaxLength)]
        public string Phone { get; set; } = null!;
    }
}
