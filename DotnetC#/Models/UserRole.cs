using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Models
{
    [Table("user_role")]
    public class UserRole
    {
        [Column("id_user")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Column("id_role")]
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
