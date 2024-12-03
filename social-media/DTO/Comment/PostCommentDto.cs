using social_media.DTO.Post;
using social_media.DTO.User;

namespace social_media.DTO.Comment
{
    public class PostCommentDto
    {
        public required Guid UserId { get; init; }
        public required Guid PostId { get; init; }
        public required string Content { get; set; }
    }
}
