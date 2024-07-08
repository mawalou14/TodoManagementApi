
using Microsoft.EntityFrameworkCore;
using TodoManagementAPI.Application.RepoContract;
using TodoManagementAPI.Domain.Entities;
using TodoManagementAPI.Infrastructure.DataAccess;

namespace TodoManagementAPI.Infrastructure.RepositoryImplementation
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Todo todo)
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Todo todo)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> GetByIdAsync(Guid todoId)
        {
            return await _context.Todos.FindAsync(todoId);
        }

        public async Task<List<Todo>> GetTodosByUserIdAsync(Guid userId)
        {
            return await _context.Todos.Where(t => t.UserId == userId).ToListAsync();
        }
    }
}
