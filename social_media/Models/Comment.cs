using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace social_media.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; init; }

        [Column("User")]
        [Required]
        public required User User { get; init; }

        [Column("Post")]
        [Required]
        public required Post Post { get; init; }

        [Column("Content")]
        [Required]
        public required string Content { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
