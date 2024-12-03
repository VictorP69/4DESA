using Microsoft.AspNetCore.Mvc;
using social_media.DTO.User;
using social_media.Models;

namespace social_media.Repository.UserRepository
{
    public interface IUserRepository
    {
        public Task<List<UserDto>> GetAll();
        public Task<UserDto> Get(string id);
        public Task<UserDto> Create([FromBody] User user);
        public Task<UserDto> Update(string id, [FromBody] UpdateUserDto updateUserDto);
        public Task<UserDto> Delete(string id);
    }
}
