using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Application.RepoContract
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task AddAsync(User user);
        Task<User> GetUserByIdAsync(Guid userId);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
