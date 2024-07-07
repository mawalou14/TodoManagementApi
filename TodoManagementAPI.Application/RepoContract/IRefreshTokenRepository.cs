
using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Application.RepoContract
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);
    }
}
