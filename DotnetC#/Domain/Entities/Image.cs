using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Domain.Entities
{
    [Table("image")]
    public class Image
    {
        [Key]
        [Column("id_image")]
        public int IdImage { get; set; }

        [Column("name_image")]
        [StringLength(255)]
        public string? NameImage { get; set; }

        [Column("is_thumbnail")]
        public bool IsThumbnail { get; set; }

        [Column("url_image")]
        [StringLength(500)]
        public string? UrlImage { get; set; }

        [Column("data_image", TypeName = "LONGTEXT")]
        public string? DataImage { get; set; }
        [Column("id_book")]
        public int IdBook { get; set; }

        public Book Book { get; set; } = null!;
    }
}
