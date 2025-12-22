using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Models
{
    [Table("favorite_book")]
    public class FavoriteBook
    {
        [Key]
        [Column("id_favorite_book")]
        public int IdFavoriteBook { get; set; }

        [Column("id_book")]
        public int BookId { get; set; }

        public Book Book { get; set; } = null!;

        [Column("id_user")]
        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
