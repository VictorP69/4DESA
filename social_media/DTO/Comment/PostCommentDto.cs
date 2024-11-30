using social_media.DTO.Post;
using social_media.DTO.User;

namespace social_media.DTO.Comment
{
    public class PostCommentDto
    {
        public required UserDto User { get; init; }
        public required PostDto Post { get; init; }
        public required string Content { get; set; }
    }
}
