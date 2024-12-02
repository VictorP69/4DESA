using Microsoft.AspNetCore.Mvc;
using social_media.DTO.User;
using social_media.Models;

namespace social_media.Repository.UserRepository
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();
        public Task<User> Get(Guid id);
        public Task<User> Create([FromBody] User user);
        public Task<User> Update(Guid id, [FromBody] UpdateUserDto updateUserDto);
        public Task<User> Delete(Guid id);
    }
}
