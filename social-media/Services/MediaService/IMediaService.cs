using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Media;
using social_media.Models;

namespace social_media.Services.MediaService
{
    public interface IMediaService
    {
        public Task<List<Media>> GetAll();
        public Task<Media> Get(Guid id);
        public Task<Media> Create([FromForm] PostMediaDto postMediaDto);
        public Task<List<Media>> GetMediasByPost(Guid postId);
        public Task<Media> Delete(Guid id);
        public Task<string> UploadFileAsync(IFormFile file);
    }
}
