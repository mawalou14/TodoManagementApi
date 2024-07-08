using TodoManagementAPI.Domain.DTOs.User;
using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Application.Services.Contracts
{
    public interface IUserService
    {
        Task<User> UpdateUserProfileAsync(Guid userId, UpdateProfile updateProfileDto);
        Task UpdateUserPasswordAsync(Guid userId, UpdatePassword updatePasswordDto);
        Task DeleteUserAsync(Guid userId);
    }
}
