namespace social_media.DTO.User
{
    public class UserDto
    {
        public Guid Id { get; init; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsPublic { get; set; }
        public bool IsContentCreator { get; set; }
    }
}
