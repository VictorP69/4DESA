using social_media.DTO.User;
using social_media.Models;

namespace social_media.DTO.Post
{
    public class CreatePostDto
    {
        public required Guid UserId { get; init; }
        public required string Title { get; set; }
        public required string Content { get; set; }
    }
}
