using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Domain.Entities
{
    [Table("role")]
    public class Role
    {
        [Key]
        [Column("id_role")]
        public int IdRole { get; set; }

        [Column("name_role")]
        [Required]
        [StringLength(255)]
        public string NameRole { get; set; } = null!;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
