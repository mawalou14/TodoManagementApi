using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Application.RepoContract
{
    public interface ITodoRepository
    {
        Task AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task DeleteAsync(Todo todo);
        Task<Todo> GetByIdAsync(Guid todoId);
        Task<List<Todo>> GetTodosByUserIdAsync(Guid userId);
    }
}
