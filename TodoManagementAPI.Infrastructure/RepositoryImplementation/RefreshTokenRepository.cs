using TodoManagementAPI.Application.RepoContract;
using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Infrastructure.RepositoryImplementation
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        public Task AddAsync(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
