using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Comment;
using social_media.DTO.Post;
using social_media.Models;
using social_media.Services.CommentService;
using social_media.Services.PostService;
using System.Xml.Linq;

namespace social_media.Controllers
{
    [ApiController]
    [Route("comment")]
    public class CommentController(ICommentService commentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResponse<List<Comment>>> All()
        {
            try
            {
                var comments = await commentService.GetAll();
                return new ApiResponse<List<Comment>>(200, comments);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Comment>>(500, errors: new List<string> { ex.Message });
            }

        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<Comment>> Details(Guid id)
        {
            try
            {
                var comment = await commentService.Get(id);
                if (comment == null)
                {
                    return new ApiResponse<Comment>(404, errors: new List<string> { "Comment not found" });
                }
                return new ApiResponse<Comment>(200, comment);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Comment>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpPost]
        public async Task<ApiResponse<Comment>> Create([FromBody] PostCommentDto postCommentDto)
        {
            try
            {
                var newComment = await commentService.Create(postCommentDto);
                return new ApiResponse<Comment>(201, newComment);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Comment>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ApiResponse<List<Comment>>> CommentsByUser(Guid userId)
        {
            try
            {
                var comments = await commentService.GetCommentsByUser(userId);
                return new ApiResponse<List<Comment>>(200, comments);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Comment>>(500, errors: new List<string> { ex.Message });
            }
        }
        [HttpGet("post/{postId}")]
        public async Task<ApiResponse<List<Comment>>> CommentsByPost(Guid postId) 
        {
            try
            {
                var comments = await commentService.GetCommentsByPost(postId);
                return new ApiResponse<List<Comment>>(200, comments);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Comment>>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpPut("{commentId}")]
        public async Task<ApiResponse<Comment>> Update(Guid commentId, [FromBody] UpdateCommentDto updateCommentDto)
        {
            try
            {
                var updatedPost = await commentService.Update(commentId, updateCommentDto);
                return new ApiResponse<Comment>(200, updatedPost);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Comment>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpDelete("{commentId}")]
        public async Task<ApiResponse<Comment>> Delete(Guid commentId)
        {
            try
            {
                var deletedComment = await commentService.Delete(commentId);
                return new ApiResponse<Comment>(200, deletedComment);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Comment>(500, errors: new List<string> { ex.Message });
            }
        }
    }
}
