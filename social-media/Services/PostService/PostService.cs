using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Comment;
using social_media.DTO.Post;
using social_media.DTO.User;
using social_media.Models;
using social_media.Repository.CommentRepository;
using social_media.Repository.PostRepository;
using social_media.Repository.UserRepository;
using social_media.Services.UserService;

namespace social_media.Services.PostService
{
    public class PostService(IPostRepository postRepository, IMapper mapper, IUserService userService, ICommentRepository commentRepository) : IPostService
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

        public async Task<DetailedPostDto> GetDetailedPost(Guid id)
        {
            var post = await postRepository.Get(id);
            var comments = await commentRepository.GetCommentsByPost(id);
            var postDto = mapper.Map<DetailedPostDto>(post);
            var commentsDto = comments.Select(x => mapper.Map<CommentDto>(x)).ToList();
            postDto.Comments = commentsDto;
            return postDto;
        }
        public async Task<List<Post>> GetPostsByUser(string userId)
        {
            var user = await userService.Get(userId);
            if (user == null)
            {
                return null;
            }
            var posts = await postRepository.GetPostsByUser(user.Id);
            return posts;
        }
        public async Task<Post> Create([FromBody] CreatePostDto createPostDto)
        {
            var user = await userService.Get(createPostDto.UserId);
            if (user == null)
            {
                return null;
            }
            var post = new Post()
            {
                UserId = user.Id,
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
