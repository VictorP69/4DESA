using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Post;
using social_media.Models;
using social_media.Services.PostService;

namespace social_media.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController(IPostService postService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResponse<List<Post>>> All()
        {
            try
            {
                var posts = await postService.GetAll();
                return new ApiResponse<List<Post>>(200, posts);
            } catch (Exception ex)
            {
                return new ApiResponse<List<Post>>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<Post>> Details(Guid id)
        {
            try
            {
                var post = await postService.Get(id);
                if (post == null)
                {
                    return new ApiResponse<Post>(404, errors: new List<string> { "Post not found" });
                }
                return new ApiResponse<Post>(200, post);
            } catch(Exception ex)
            {
                return new ApiResponse<Post>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpPost]
        public async Task<ApiResponse<Post>> Create([FromBody] CreatePostDto createPostDto)
        {
            try
            {
                var newPost = await postService.Create(createPostDto);
                if (newPost == null)
                {
                    return new ApiResponse<Post>(404, errors: new List<string> { "User not found" });
                }
                return new ApiResponse<Post>(201, newPost);
            } catch(Exception ex)
            {
                return new ApiResponse<Post>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ApiResponse<List<Post>>> PostsByUser(Guid userId)
        {
            try
            {
                var posts = await postService.GetPostsByUser(userId);
                return new ApiResponse<List<Post>>(200, posts);
            } catch(Exception ex)
            {
                return new ApiResponse<List<Post>>(500, errors: new List<string> { ex.Message });
            }
        }
        [HttpPut("{postId}")]
        public async Task<ApiResponse<Post>> Update(Guid postId, [FromBody] UpdatePostDto updatePostDto)
        {
            try
            {
                var updatedPost = await postService.Update(postId, updatePostDto);
                return new ApiResponse<Post>(200, updatedPost);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Post>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpDelete("{postId}")]
        public async Task<ApiResponse<Post>> Delete(Guid postId)
        {
            try
            {
                var deletedPost = await postService.Delete(postId);
                return new ApiResponse<Post>(200, deletedPost);
            } catch (Exception ex)
            {
                return new ApiResponse<Post>(500, errors: new List<string> { ex.Message });
            }
        }
    }
}
