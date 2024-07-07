using TodoManagementAPI.Application.RepoContract;
using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Infrastructure.RepositoryImplementation
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
