using social_media.DTO.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace social_media.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; init; }

        [Column("Username")]
        [MaxLength(100)]
        [Required]
        public required string Username { get; set; }

        [Column("Email")]
        [MaxLength(100)]
        [Required]
        public required string Email { get; set; }

        [Column("Password")]
        [Required]
        public required string Password { get; set; }

        [Column("IsPublic")]
        public bool IsPublic { get; set; } = true;

        [Column("IsContentCreator")]
        public bool IsContentCreator { get; set; } = false;
    }
}
