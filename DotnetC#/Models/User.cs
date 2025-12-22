using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id_user")]
        public int IdUser { get; set; }

        [Column("first_name")]
        [StringLength(255)]
        public string? FirstName { get; set; }

        [Column("last_name")]
        [StringLength(255)]
        public string LastName { get; set; } = null!;

        [Column("username")]
        [StringLength(255)]
        public string? Username { get; set; }

        [Column("password", TypeName = "varchar(512)")]
        [Required]
        public string Password { get; set; } = null!;

        [Column("gender")]
        public char? Gender { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("email")]
        [StringLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        [Column("phone_number")]
        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [Column("delivery_address")]
        [StringLength(500)]
        public string? DeliveryAddress { get; set; }

        [Column("avatar")]
        [StringLength(500)]
        public string? Avatar { get; set; }

        [Column("enabled")]
        public bool Enabled { get; set; } = true;

        [Column("activation_code")]
        [StringLength(255)]
        public string? ActivationCode { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
