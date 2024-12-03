using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using social_media.Contexts;
using social_media.DTO.Media;
using social_media.Models;

namespace social_media.Repository.MediaRepository
{
    public class MediaRepository(DataContext context) : IMediaRepository
    {
        public async Task<List<Media>> GetAll()
        {
            var medias = await context.Media.ToListAsync();
            return medias;
        }
        public async Task<Media> Get(Guid id)
        {
            var media = await context.Media.FindAsync(id);
            return media;
        }
        public async Task<Media> Create(Media media)
        {
            await context.Media.AddAsync(media);
            await context.SaveChangesAsync();
            return media;
        }
        public async Task<List<Media>> GetMediasByPost(Post post)
        {
            var comments = await context.Media.Where(m => m.PostId == post.Id).ToListAsync();
            return comments;
        }

        public async Task<Media> Delete(Guid id)
        {
            var media = await Get(id);
            context.Media.Remove(media);
            await context.SaveChangesAsync();
            return media;
        }
    }
}
