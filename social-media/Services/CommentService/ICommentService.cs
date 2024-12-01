using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Comment;
using social_media.Models;

namespace social_media.Services.CommentService
{
    public interface ICommentService
    {
        public Task<List<Comment>> GetAll();
        public Task<Comment> Get(Guid id);
        public Task<List<Comment>> GetCommentsByUser(Guid userId);
        public Task<List<Comment>> GetCommentsByPost(Guid postId);
        public Task<Comment> Create([FromBody] PostCommentDto postCommentDto);
        public Task<Comment> Update(Guid id, [FromBody] UpdateCommentDto updateCommentDto);
        public Task<Comment> Delete(Guid id);
    }
}
