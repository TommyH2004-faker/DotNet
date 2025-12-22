using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Models
{
    [Table("book")]
    public class Book
    {
        [Key]
        [Column("id_book")]
        public int IdBook { get; set; }

        [Column("name_book")]
        [Required]
        [StringLength(255)]
        public string NameBook { get; set; } = null!;

        [Column("author")]
        [Required]
        [StringLength(255)]
        public string Author { get; set; } = null!;

        [Column("isbn")]
        [Required]
        [StringLength(50)]
        public string Isbn { get; set; } = null!;

        [Column("description", TypeName = "LONGTEXT")]
        [Required]
        public string Description { get; set; } = null!;

        [Column("list_price")]
        public double ListPrice { get; set; }

        [Column("sell_price")]
        public double SellPrice { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("avg_rating")]
        public double? AvgRating { get; set; }

        [Column("sold_quantity")]
        public int? SoldQuantity { get; set; }

        [Column("discount_percent")]
        public int DiscountPercent { get; set; }

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<OrdersDetail> OrderDetails { get; set; } = new List<OrdersDetail>();

        public ICollection<FavoriteBook> FavoriteBooks { get; set; } = new List<FavoriteBook>();

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
