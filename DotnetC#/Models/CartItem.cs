using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotnetC_.Models;
namespace DotnetC_.Models
{
    [Table("cart_item")]
    public class CartItem
    {
        [Key]
        [Column("id_cart")]
        public int IdCart { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("id_book")]
        public int BookId { get; set; }

        public Book Book { get; set; } = null!;

        [Column("id_user")]
        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
