﻿using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Comment;
using social_media.Models;
using social_media.Repository.CommentRepository;
using social_media.Services.PostService;
using social_media.Services.UserService;

namespace social_media.Services.CommentService
{
    public class CommentService(ICommentRepository commentRepository, IMapper mapper, IUserService userService, IPostService postService, IHttpContextAccessor httpContextAccessor) : ICommentService
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
        public async Task<List<Comment>> GetCommentsByUser(string userId)
        {
            var user = await userService.Get(userId);
            if (user == null)
            {
                return null;
            }
            var comments = await commentRepository.GetCommentsByUser(user.Id);
            return comments;
        }
        public async Task<List<Comment>> GetCommentsByPost(Guid postId)
        {
            var post = await postService.Get(postId);
            if (post == null)
            {
                return null;
            }
            var comments = await commentRepository.GetCommentsByPost(post);
            return comments;
        }
        public async Task<Comment> Create([FromBody] PostCommentDto postCommentDto)
        {
            var user = await userService.Get(postCommentDto.UserId);
            var post = await postService.Get(postCommentDto.PostId);

            var comment = new Comment()
            {
                UserId = postCommentDto.UserId,
                PostId = postCommentDto.PostId,
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

        public async Task<Comment> HideComment(Guid commentId)
        {
            var currentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId is null)
            {
                throw new Exception("User must be logged in");
            }

            var comment = await commentRepository.Get(commentId);
            if (comment is null)
            {
                throw new Exception("Comment could not be found");
            }
            
            var originalPost = await postService.Get(comment.PostId)!;

            if (originalPost.UserId != currentUserId)
            {
                throw new Exception("You can't hide this comment");
            }
            
            comment.IsHidden = true;
            commentRepository.Save();

            return comment;
        }
    }
}
