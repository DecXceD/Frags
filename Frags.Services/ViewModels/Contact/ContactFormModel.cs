using System.ComponentModel.DataAnnotations;

namespace Frags.Services.ViewModels.Contact
{
    public class ContactFormModel
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;
    }
}
