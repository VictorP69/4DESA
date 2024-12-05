using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Media;
using social_media.Models;
using social_media.Services.MediaService;

namespace social_media.Controllers
{
    [ApiController]
    [Route("media")]
    public class MediaController(IMediaService mediaService) : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResponse<List<Media>>> Index()
        {
            try
            {
                var medias = await mediaService.GetAll();
                return new ApiResponse<List<Media>>(200, medias);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Media>>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpGet("{mediaId}")]
        public async Task<ApiResponse<Media>> Details(Guid mediaId)
        {
            try
            {
                var medias = await mediaService.Get(mediaId);
                return new ApiResponse<Media>(200, medias);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Media>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpPost]
        public async Task<ApiResponse<Media>> Create([FromForm] PostMediaDto postMediaDto)
        {
            try
            {
                var medias = await mediaService.Create(postMediaDto);
                return new ApiResponse<Media>(200, medias);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Media>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpGet("post/{postId}")]
        public async Task<ApiResponse<List<Media>>> MediasByPost(Guid postId)
        {
            try
            {
                var medias = await mediaService.GetMediasByPost(postId);
                return new ApiResponse<List<Media>>(200, medias);
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Media>>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpDelete("{mediaId}")]
        public async Task<ApiResponse<Media>> Delete(Guid mediaId)
        {
            try
            {
                var medias = await mediaService.Delete(mediaId);
                return new ApiResponse<Media>(200, medias);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Media>(500, errors: new List<string> { ex.Message });
            }
        }
    }
}
