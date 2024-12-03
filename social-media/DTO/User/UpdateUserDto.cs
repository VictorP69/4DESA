namespace social_media.DTO.User
{
    public class UpdateUserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public bool IsPublic { get; set; }
        public bool IsContentCreator { get; set; }
    }
}
