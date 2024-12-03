using Microsoft.AspNetCore.Mvc;
using social_media.DTO.User;
using social_media.Models;

namespace social_media.Services.UserService
{
    public interface IUserService
    {
        public Task<List<User>> GetAll();
        public Task<User> Get(Guid id);
        public Task<User> Create([FromBody] PostUserDto postUserDto);
        public Task<User> Update(Guid id, [FromBody] UpdateUserDto updateUserDto);
        public Task<User> Delete(Guid id);
    }
}
