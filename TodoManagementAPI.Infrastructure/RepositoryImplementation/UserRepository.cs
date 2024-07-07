using Microsoft.EntityFrameworkCore;
using TodoManagementAPI.Application.RepoContract;
using TodoManagementAPI.Domain.Entities;
using TodoManagementAPI.Infrastructure.DataAccess;

namespace TodoManagementAPI.Infrastructure.RepositoryImplementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
