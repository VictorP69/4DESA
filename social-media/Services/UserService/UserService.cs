using Microsoft.AspNetCore.Mvc;
using social_media.DTO.User;
using social_media.Models;
using social_media.Repository.UserRepository;
using AutoMapper;

namespace social_media.Services.UserService
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {

        public async Task<List<UserDto>> GetAll()
        {
            var users = await userRepository.GetAll();
            return users;
        }

        public async Task<UserDto> Get(string id)
        {
            var user = await userRepository.Get(id);
            return user;
        }
        public async Task<UserDto> Update(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            var updatedUser = await userRepository.Update(id, updateUserDto);
            return updatedUser;
        }
        public async Task<UserDto> Delete(string id)
        {
            var deletedUser = await userRepository.Delete(id);
            return deletedUser;
        }
    }
}
