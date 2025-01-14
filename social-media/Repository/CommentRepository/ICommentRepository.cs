﻿using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Comment;
using social_media.Models;

namespace social_media.Repository.CommentRepository
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAll();
        public Task<Comment> Get(Guid id);
        public Task<List<Comment>> GetCommentsByUser(string userId);
        public Task<List<Comment>> GetCommentsByPost(Post post);
        public Task<Comment> Create(Comment comment);
        public Task<Comment> Update(Guid id, [FromBody] UpdateCommentDto updateCommentDto);
        public Task<Comment> Delete(Guid id);
        public Task<List<Comment>> GetCommentsByPost(Guid postId);
        public void Save();
    }
}
