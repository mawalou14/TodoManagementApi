using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoManagementAPI.Application.Services.Contracts;
using TodoManagementAPI.Application.Services.Implementations;
using TodoManagementAPI.Domain.DTOs.User;

namespace TodoManagementAPI.App.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }


        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserProfile(Guid userId, [FromBody] UpdateProfile updateProfileDto)
        {
            try
            {
                var updatedUser = await userService.UpdateUserProfileAsync(userId, updateProfileDto);
                return Ok(mapper.Map<UserProfile>(updatedUser));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{userId}/update-password")]
        public async Task<IActionResult> UpdateUserPassword(Guid userId, [FromBody] UpdatePassword updatePasswordDto)
        {
            try
            {
                await userService.UpdateUserPasswordAsync(userId, updatePasswordDto);
                return Ok("Password updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                await userService.DeleteUserAsync(userId);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
