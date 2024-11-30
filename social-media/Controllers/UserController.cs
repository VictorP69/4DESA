using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.User;
using social_media.Models;
using social_media.Services.UserService;

namespace social_media.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResponse<List<User>>> All()
        {
            try
            {
                var users = await userService.GetAll();
                return new ApiResponse<List<User>>(200, users);
            } catch (Exception ex)
            {
                return new ApiResponse<List<User>>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpGet("{userId}")]
        public async Task<ApiResponse<User>> Details(Guid userId)
        {
            try
            {
                var user = await userService.Get(userId);
                if (user == null)
                {
                    return new ApiResponse<User>(404, errors: new List<string> { "User not found" });
                }
                return new ApiResponse<User>(200, user);
            } catch(Exception ex)
            {
                return new ApiResponse<User>(500, errors: new List<string> { ex.Message });
            }

        }

        [HttpPost]
        public async Task<ApiResponse<User>> Create([FromBody] PostUserDto postUserDto)
        {
            try
            {
                var newUser = await userService.Create(postUserDto);
                return new ApiResponse<User>(201, newUser);
            } catch(Exception ex)
            {
                return new ApiResponse<User>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpPut("{userId}")]
        public async Task<ApiResponse<User>> Edit(Guid userId, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                var updatedUser = await userService.Update(userId, updateUserDto);
                return new ApiResponse<User>(200, updatedUser);
            } catch(Exception ex)
            {
                return new ApiResponse<User>(500, errors: new List<string> { ex.Message });
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ApiResponse<User>> Delete(Guid userId)
        {
            try
            {
                var deletedUser = await userService.Delete(userId);
                return new ApiResponse<User>(200, deletedUser);
            } catch (Exception ex)
            {
                return new ApiResponse<User>(500, errors: new List<string> { ex.Message });
            }
        }
    }
}
