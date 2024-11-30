using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Comment;
using social_media.Models;
using social_media.Repository.CommentRepository;

namespace social_media.Services.CommentService
{
    public class CommentService(ICommentRepository commentRepository, IMapper mapper) : ICommentService
    {
        public async Task<List<Comment>> GetAll()
        {
            var comments = await commentRepository.GetAll();
            return comments;
        }
        public async Task<Comment> Get(Guid id)
        {
            var comment = await commentRepository.Get(id);
            return comment;
        }
        public async Task<List<Comment>> GetCommentsByUser(User user)
        {
            var comments = await commentRepository.GetCommentsByUser(user);
            return comments;
        }
        public async Task<Comment> Create([FromBody] PostCommentDto postCommentDto)
        {
            var comment = new Comment()
            {
                User = mapper.Map<User>(postCommentDto.User),
                Post = mapper.Map<Post>(postCommentDto.Post),
                Content = postCommentDto.Content
            };
            var newComment = await commentRepository.Create(comment);
            return newComment;
        }
        public async Task<Comment> Update(Guid id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var updatedComment = await commentRepository.Update(id, updateCommentDto);
            return updatedComment;
        }
        public async Task<Comment> Delete(Guid id)
        {
            var deletedComment = await commentRepository.Delete(id);
            return deletedComment;
        }
    }
}
