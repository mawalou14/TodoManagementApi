using TodoManagementAPI.Application.RepoContract;
using TodoManagementAPI.Application.Services.Contracts;
using TodoManagementAPI.Domain.DTOs.User;
using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<User> UpdateUserProfileAsync(Guid userId, UpdateProfile updateProfileDto)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            user.FullName = updateProfileDto.FullName;

            await userRepository.UpdateAsync(user);

            return user;
        }

        public async Task UpdateUserPasswordAsync(Guid userId, UpdatePassword updatePasswordDto)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(updatePasswordDto.CurrentPassword, user.PasswordHash))
            {
                throw new Exception("Current password is incorrect.");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updatePasswordDto.Password);

            await userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            await userRepository.DeleteAsync(user);
        }
    }
}