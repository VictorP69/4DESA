using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace social_media.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; init; }

        [Column("UserId")]
        [Required]
        public required string UserId { get; init; }

        [Column("PostId")]
        [Required]
        public required Guid PostId { get; init; }

        [Column("Content")]
        [Required]
        public required string Content { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
