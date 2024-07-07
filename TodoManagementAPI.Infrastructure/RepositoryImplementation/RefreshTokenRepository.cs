using TodoManagementAPI.Application.RepoContract;
using TodoManagementAPI.Domain.Entities;
using TodoManagementAPI.Infrastructure.DataAccess;

namespace TodoManagementAPI.Infrastructure.RepositoryImplementation
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _context;

        public RefreshTokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }
    }
}
