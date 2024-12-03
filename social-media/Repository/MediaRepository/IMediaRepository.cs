using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Media;
using social_media.Models;

namespace social_media.Repository.MediaRepository
{
    public interface IMediaRepository
    {
        public Task<List<Media>> GetAll();
        public Task<Media> Get(Guid id);
        public Task<Media> Create(Media media);
        public Task<List<Media>> GetMediasByPost(Post post);
        public Task<Media> Delete(Guid id);
    }
}
