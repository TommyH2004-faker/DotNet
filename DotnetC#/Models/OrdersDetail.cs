using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Models
{
    [Table("order_detail")]
    public class OrdersDetail
    {
        [Key]
        [Column("id_order_detail")]
        public long IdOrderDetail { get; set; }

        [Column("quantity")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Column("price")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Column("is_review")]
        public bool IsReview { get; set; }

        [Column("id_book")]
        public int BookId { get; set; }

        public Book Book { get; set; } = null!;

        [Column("id_order")]
        public int? OrderId { get; set; }

        public Orders? Order { get; set; }
    }
}
