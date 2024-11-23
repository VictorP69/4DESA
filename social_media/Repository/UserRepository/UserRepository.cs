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

        public async Task<List<User>> GetAll()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        public async Task<User> Get(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            return user;
        }
        public async Task<User> Create(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }
        public async Task<User> Update(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await Get(id);
            user.Username = updateUserDto.Username;
            user.Password = updateUserDto.Password;
            user.IsPublic = updateUserDto.IsPublic;
            user.IsContentCreator = updateUserDto.IsPrivate;

            await context.SaveChangesAsync();
           
            return user;
        }
        public async Task<User> Delete(Guid id)
        {
            var user = await Get(id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

    }
}
