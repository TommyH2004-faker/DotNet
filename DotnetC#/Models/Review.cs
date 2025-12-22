
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotnetC_.Models
{
    [Table("review")]
    public class Review
    {
        [Key]
        [Column("id_review")]
        public int IdReview { get; set; }

        [Column("content")]
        [StringLength(1000)]
        public string? Content { get; set; }

        [Column("rating_point")]
        public float? RatingPoint { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("id_book")]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        [Column("id_user")]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [Column("id_order_detail")]
        public long? OrderDetailId { get; set; }
        public OrdersDetail? OrderDetail { get; set; }
    }
}
