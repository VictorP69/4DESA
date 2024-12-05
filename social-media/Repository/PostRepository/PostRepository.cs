using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using social_media.Contexts;
using social_media.DTO.Post;
using social_media.Models;

namespace social_media.Repository.PostRepository
{
    public class PostRepository(DataContext context, IMapper mapper) : IPostRepository
    {
        public async Task<List<Post>> GetAll()
        {
            var posts = await context.Posts.ToListAsync();
            return posts;
        }
        public async Task<Post> Get(Guid id)
        {
            var post = await context.Posts.FindAsync(id);
            return post;
        }
        public async Task<List<Post>> GetPostsByUser(string userId)
        {
            var posts = await context.Posts.Where(p => p.UserId == userId).ToListAsync();
            return posts;
        }
        public async Task<Post> Create(Post post)
        {
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
            return post;
        }
        public async Task<Post> Update(Guid id, [FromBody] UpdatePostDto updatePostDto)
        {
            var post = await Get(id);
            post.Title = updatePostDto.Title;
            post.Content = updatePostDto.Content;

            await context.SaveChangesAsync();

            return post;
        }
        public async Task<Post> Delete(Guid id)
        {
            var post = await Get(id);
            context.Posts.Remove(post);
            await context.SaveChangesAsync();
            return post;
        }
    }
}
