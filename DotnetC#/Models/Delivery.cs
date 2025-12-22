using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Models
{
    [Table("delivery")]
    public class Delivery
    {
        [Key]
        [Column("id_delivery")]
        public int IdDelivery { get; set; }

        [Column("name_delivery")]
        [Required]
        [StringLength(255)]
        public string NameDelivery { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        [Column("fee_delivery")]
        [Range(0, double.MaxValue)]
        public double FeeDelivery { get; set; }

        // Navigation property
        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
