using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Domain.Entities
{
    [Table("orders")]
    public class Orders
    {
        [Key]
        [Column("id_order")]
        public int IdOrder { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("delivery_address")]
        [StringLength(500)]
        public string DeliveryAddress { get; set; } = null!;

        [Column("phone_number")]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;

        [Column("full_name")]
        [StringLength(255)]
        public string FullName { get; set; } = null!;

        [Column("total_price_product")]
        public double TotalPriceProduct { get; set; }

        [Column("fee_delivery")]
        public double FeeDelivery { get; set; }

        [Column("fee_payment")]
        public double FeePayment { get; set; }

        [Column("total_price")]
        public double TotalPrice { get; set; }

        [Column("status")]
        [StringLength(50)]
        public string Status { get; set; } = null!;

        [Column("note")]
        [StringLength(1000)]
        public string? Note { get; set; }

        [Column("id_user")]
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        [Column("id_payment")]
        public int? PaymentId { get; set; }

        public Payment? Payment { get; set; }

        [Column("id_delivery")]
        public int? DeliveryId { get; set; }

        public Delivery? Delivery { get; set; }

        public ICollection<OrdersDetail> OrderDetails { get; set; } = new List<OrdersDetail>();
    }
}
