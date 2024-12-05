using social_media.DTO.Comment;

namespace social_media.DTO.Post;

public class DetailedPostDto : PostDto
{
    public List<CommentDto> Comments { get; set; } = [];
}