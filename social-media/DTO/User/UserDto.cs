namespace social_media.DTO.User
{
    public class UserDto
    {
        public string Id { get; init; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public bool IsPublic { get; set; }
        public bool IsContentCreator { get; set; }
    }
}
