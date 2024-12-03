using System.ComponentModel.DataAnnotations;

namespace social_media.DTO.Media
{
    public class PostMediaDto
    {
        public Guid PostId { get; set; }
        public IFormFile File { get; set; }
    }
}
