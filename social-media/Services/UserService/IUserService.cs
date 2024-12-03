using Microsoft.AspNetCore.Mvc;
using social_media.DTO.User;

namespace social_media.Services.UserService
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAll();
        public Task<UserDto> Get(string id);
        public Task<UserDto> Update(string id, [FromBody] UpdateUserDto updateUserDto);
        public Task<UserDto> Delete(string id);
    }
}
