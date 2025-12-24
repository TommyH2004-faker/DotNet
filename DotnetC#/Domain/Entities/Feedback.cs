using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetC_.Domain.Entities
{
    [Table("feedback")]
    public class Feedback
    {
        [Key]
        [Column("id_feedback")]
        public int IdFeedback { get; set; }

        [Column("title")]
        [StringLength(255)]
        public string? Title { get; set; }

        [Column("comment")]
        [StringLength(1000)]
        public string? Comment { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("is_readed")]
        public bool IsReaded { get; set; }

        [Column("id_user")]
        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
