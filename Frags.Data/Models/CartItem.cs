using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frags.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int FragranceId { get; set; }
        public Fragrance Fragrance { get; set; } = null!;

        public int Quantity { get; set; }

        [Required]
        public string SessionId { get; set; } = null!;
    }
}
