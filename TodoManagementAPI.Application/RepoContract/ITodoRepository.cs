using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Application.RepoContract
{
    public interface ITodoRepository
    {
        Task<Todo> AddAsync(Todo todo);
        Task<Todo> UpdateAsync(Todo todo);
        Task<Todo> DeleteAsync(Todo todo);
        Task<Todo> GetByIdAsync(Guid todoId);
        Task<List<Todo>> GetTodosByUserIdAsync(Guid userId);
    }
}
