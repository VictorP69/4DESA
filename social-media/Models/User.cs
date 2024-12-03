using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace social_media.Models
{
    public class User : IdentityUser
    {
        [Column("IsPublic")]
        public bool IsPublic { get; set; } = true;

        [Column("IsContentCreator")]
        public bool IsContentCreator { get; set; } = false;
    }
}
