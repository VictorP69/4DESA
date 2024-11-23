using Microsoft.AspNetCore.Mvc;
using social_media.DTO.User;
using social_media.Models;
using social_media.Repository.UserRepository;
using AutoMapper;

namespace social_media.Services.UserService
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {

        public async Task<List<User>> GetAll()
        {
            var users = await userRepository.GetAll();
            return users;
        }

        public async Task<User> Get(Guid id)
        {
            var user = await userRepository.Get(id);
            return user;
        }
        public async Task<User> Create([FromBody] PostUserDto postUserDto)
        {
            var user = new User()
            {
                Username = postUserDto.Username,
                Email = postUserDto.Email,
                Password = postUserDto.Password,
            };
            var newUser = await userRepository.Create(user);
            return newUser;
        }
        public async Task<User> Update(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var updatedUser = await userRepository.Update(id, updateUserDto);
            return updatedUser;
        }
        public async Task<User> Delete(Guid id)
        {
            var deletedUser = await userRepository.Delete(id);
            return deletedUser;
        }
    }
}
