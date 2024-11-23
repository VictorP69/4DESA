using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace social_media.Models
{
    public class Media
    {
        [Key]
        public Guid Id { get; init; }

        [Column("Post")]
        [Required]
        public required Post Post { get; init; }

        [Column("Url")]
        [Required]
        public required string Url { get; set; }

        [Column("Type")]
        [MaxLength(100)]
        [Required]
        public required string Type { get; set; }
    }
}
