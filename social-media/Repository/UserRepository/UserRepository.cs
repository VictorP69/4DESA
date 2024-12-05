using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using social_media.Contexts;
using social_media.DTO.User;
using social_media.Models;

namespace social_media.Repository.UserRepository
{
    public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
    {
        public async Task<List<UserDto>> GetAll()
        {
            var users = await context.Users.ToListAsync();
            return mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> Get(string id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> Create(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> Update(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var mappedUser = mapper.Map<User>(user);
            mappedUser.UserName = updateUserDto.UserName;
            mappedUser.PasswordHash = updateUserDto.PasswordHash;
            mappedUser.IsPublic = updateUserDto.IsPublic;
            mappedUser.IsContentCreator = updateUserDto.IsContentCreator;
            await context.SaveChangesAsync();
           
            return mapper.Map<UserDto>(mappedUser);
        }
        public async Task<UserDto> Delete(string id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }

    }
}
