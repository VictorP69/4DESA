using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Post;
using social_media.Models;

namespace social_media.Repository.PostRepository
{
    public interface IPostRepository
    {
        public Task<List<Post>> GetAll();
        public Task<Post> Get(Guid id);
        public Task<List<Post>> GetPostsByUser(string userId);
        public Task<Post> Create([FromBody] Post post);
        public Task<Post> Update(Guid id, [FromBody] UpdatePostDto updatePostDto);
        public Task<Post> Delete(Guid id);
    }
}
