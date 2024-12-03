namespace social_media.DTO.User
{
    public class UpdateUserDto
    {
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public bool IsPublic { get; set; }
        public bool IsContentCreator { get; set; }
    }
}
