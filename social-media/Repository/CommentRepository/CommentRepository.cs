using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using social_media.Contexts;
using social_media.DTO.Comment;
using social_media.DTO.User;
using social_media.Models;

namespace social_media.Repository.CommentRepository
{
    public class CommentRepository(DataContext context) : ICommentRepository
    {
        public async Task<List<Comment>> GetAll()
        {
            var comments = await context.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment> Get(Guid id)
        {
            var comment = await context.Comments.FindAsync(id);
            return comment;
        }
        public async Task<List<Comment>> GetCommentsByUser(string userId)
        {
            var comments = await context.Comments.Where(c => c.UserId == userId).ToListAsync();
            return comments;
        }
        public async Task<List<Comment>> GetCommentsByPost(Post post)
        {
            var comments = await context.Comments.Where(c => c.PostId == post.Id).ToListAsync();
            return comments;
        }
        public async Task<Comment> Create(Comment comment)
        {
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
            return comment;
        }
        public async Task<Comment> Update(Guid id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var comment = await Get(id);
            comment.Content = updateCommentDto.Content;

            await context.SaveChangesAsync();

            return comment;
        }
        public async Task<Comment> Delete(Guid id)
        {
            var comment = await Get(id);
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public Task<List<Comment>> GetCommentsByPost(Guid postId)
        {
            var comments = context.Comments.Where(c => c.PostId == postId);
            return comments.ToListAsync();
        }

        public void Save()
        { 
            context.SaveChanges();
        }
    }
}
