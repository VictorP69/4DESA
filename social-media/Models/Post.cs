using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace social_media.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; init; }

        [Column("User")]
        [Required]
        public required string UserId { get; set; }

        [Column("Title")]
        [MaxLength(100)]
        [Required]
        public required string Title { get; set; }

        [Column("Content")]
        [Required]
        public required string Content { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
