using social_media.DTO.User;

namespace social_media.DTO.Post
{
    public class PostDto
    {
        public Guid Id { get; init; }
        public required UserDto User { get; init; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
