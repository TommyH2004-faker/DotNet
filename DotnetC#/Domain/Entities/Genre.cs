using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Domain.Entities
{
    [Table("genre")]
    public class Genre
    {
        [Key]
        [Column("id_genre")]
        public int IdGenre { get; set; }

        [Column("name_genre")]
        [Required]
        [StringLength(255)]
        public string NameGenre { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
