using social_media.DTO.Post;
using social_media.DTO.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace social_media.DTO.Comment
{
    public class CommentDto
    {
        public Guid Id { get; init; }
        public required UserDto User { get; init; }
        public required PostDto Post { get; init; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
