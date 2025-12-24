using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Domain.Entities
{
    [Table("payment")]
    public class Payment
    {
        [Key]
        [Column("id_payment")]
        public int IdPayment { get; set; }

        [Column("name_payment")]
        [Required]
        [StringLength(255)]
        public string NamePayment { get; set; } = null!;

        [Column("description")]
        [StringLength(1000)]
        public string? Description { get; set; }

        [Column("fee_payment")]
        [Range(0, double.MaxValue)]
        public double FeePayment { get; set; }

        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
