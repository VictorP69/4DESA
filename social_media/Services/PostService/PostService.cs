using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Post;
using social_media.DTO.User;
using social_media.Models;
using social_media.Repository.PostRepository;
using social_media.Repository.UserRepository;

namespace social_media.Services.PostService
{
    public class PostService(IPostRepository postRepository, IMapper mapper) : IPostService
    {
        public async Task<List<Post>> GetAll()
        {
            var posts = await postRepository.GetAll();
            return posts;
        }
        public async Task<Post> Get(Guid id)
        {
            var post = await postRepository.Get(id);
            return post;
        }
        public async Task<Post> Create([FromBody] CreatePostDto createPostDto)
        {
            var post = new Post()
            {
                User = mapper.Map<User>(createPostDto.User),
                Title = createPostDto.Title,
                Content = createPostDto.Content
            };
            var newPost = await postRepository.Create(post);
            return newPost;
        }
        public async Task<Post> Update(Guid id, [FromBody] UpdatePostDto updatePostDto)
        {
            var updatedPost = await postRepository.Update(id, updatePostDto);
            return updatedPost;
        }
        public async Task<Post> Delete(Guid id)
        {
            var deletedPost = await postRepository.Delete(id);
            return deletedPost;
        }
    }
}
