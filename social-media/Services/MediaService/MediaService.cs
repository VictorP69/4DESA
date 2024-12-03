using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.Media;
using social_media.Models;
using social_media.Repository.MediaRepository;
using social_media.Services.PostService;

namespace social_media.Services.MediaService
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly string _connectionString;
        private readonly string _containerName;
        private readonly IPostService _postService;

        public MediaService(IMediaRepository mediaRepository, IConfiguration configuration, IPostService postService)
        {
            _mediaRepository = mediaRepository;
            _connectionString = configuration["AzureBlobStorage:ConnectionString"];
            _containerName = configuration["AzureBlobStorage:ContainerName"];
            _postService = postService;
        }

        public async Task<List<Media>> GetAll()
        {
            var medias = await _mediaRepository.GetAll();
            return medias;
        }

        public async Task<Media> Get(Guid id)
        {
            var media = await _mediaRepository.Get(id);
            return media;
        }

        public async Task<Media> Create([FromBody] PostMediaDto postMediaDto)
        {
            var uploadedUrl = await UploadFileAsync(postMediaDto.File);

            var media = new Media()
            {
                PostId = postMediaDto.PostId,
                Url = uploadedUrl,
                Type = postMediaDto.File.GetType().ToString()
            };
            var newMedia = await _mediaRepository.Create(media);
            return newMedia;
        }

        public async Task<List<Media>> GetMediasByPost(Guid postId)
        {
            var post = await _postService.Get(postId);
            if (post == null)
            {
                return null;
            }
            var medias = await _mediaRepository.GetMediasByPost(post);
            return medias;
        }

        public async Task<Media> Delete(Guid id)
        {
            var mediaToDelete = await _mediaRepository.Get(id);

            if (mediaToDelete == null)
            {
                throw new Exception("Media not found");
            }

            var blobContainerClient = new BlobContainerClient(_connectionString, _containerName);
            var blobClient = blobContainerClient.GetBlobClient(mediaToDelete.Url.Split('/').Last());

            await blobClient.DeleteIfExistsAsync();

            var deletedMedia = await _mediaRepository.Delete(id);

            return deletedMedia;
        }


        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName)?.ToLower();
            string contentType;

            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".mp4":
                    contentType = "video/mp4";
                    break;
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".txt":
                    contentType = "text/plain";
                    break;
                case ".doc":
                    contentType = "application/msword";
                    break;
                case ".docx":
                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ".xls":
                    contentType = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case ".wav":
                    contentType = "audio/wav";
                    break;
                default:
                    throw new InvalidOperationException("Unsupported file type.");
            }

            var blobContainerClient = new BlobContainerClient(_connectionString, _containerName);

            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var blobName = Guid.NewGuid().ToString() + fileExtension;

            var blobClient = blobContainerClient.GetBlobClient(blobName);

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = contentType });
            }

            return blobClient.Uri.ToString();
        }
    }
}
