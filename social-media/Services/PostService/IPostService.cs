using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Post;
using social_media.Models;

namespace social_media.Services.PostService
{
    public interface IPostService
    {
        public Task<List<Post>> GetAll();
        public Task<Post> Get(Guid id);
        public Task<List<Post>> GetPostsByUser(string userId);
        public Task<Post> Create([FromBody] CreatePostDto post);
        public Task<Post> Update(Guid id, [FromBody] UpdatePostDto post);
        public Task<Post> Delete(Guid id);
    }
}
