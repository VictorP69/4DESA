using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using social_media.DTO.User;
using social_media.Middleware;
using social_media.Models;
using social_media.Services.AuthService;
using social_media.Services.UserService;

namespace social_media.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController(IUserService userService, IAuthService authService) : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResponse<List<UserDto>>> All()
        {
            try
            {
                var users = await userService.GetAll();
                return new ApiResponse<List<UserDto>>(200, users);
            } catch (Exception ex)
            {
                return new ApiResponse<List<UserDto>>(500, errors: new List<string> { ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{userId}")]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public async Task<ApiResponse<UserDto>> Details(string userId)
        {
            try
            {
                var user = await userService.Get(userId);
                if (user == null)
                {
                    return new ApiResponse<UserDto>(404, errors: new List<string> { "User not found" });
                }
                return new ApiResponse<UserDto>(200, user);
            } catch(Exception ex)
            {
                return new ApiResponse<UserDto>(500, errors: new List<string> { ex.Message });
            }

        }

        [Authorize]
        [HttpPut("{userId}")]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public async Task<ApiResponse<UserDto>> Edit(string userId, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                var updatedUser = await userService.Update(userId, updateUserDto);
                return new ApiResponse<UserDto>(200, updatedUser);
            } catch(Exception ex)
            {
                return new ApiResponse<UserDto>(500, errors: new List<string> { ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{userId}")]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public async Task<ApiResponse<UserDto>> Delete(string userId)
        {
            try
            {
                var deletedUser = await userService.Delete(userId);
                return new ApiResponse<UserDto>(200, deletedUser);
            } catch (Exception ex)
            {
                return new ApiResponse<UserDto>(500, errors: new List<string> { ex.Message });
            }
        }
    }
}
