namespace social_media.Models
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse(int statusCode, T data = default, List<string> errors = null)
        {
            StatusCode = statusCode;
            Data = data;
            Errors = errors ?? new List<string>();
        }
    }
}
