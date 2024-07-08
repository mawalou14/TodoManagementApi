using TodoManagementAPI.Domain.DTOs.Todo;

namespace TodoManagementAPI.Application.Services.Contracts
{
    public interface ITodoService
    {
        Task CreateTodoAsync(CreateTodoDto createTodoDto);
        Task UpdateTodoAsync(UpdateTodoDto updateTodoDto);
        Task DeleteTodoAsync(Guid todoId);
        Task<List<GetTodoDto>> GetUserTodosAsync(Guid userId);
        Task<TodoDto> GetTodoByIdAsync(Guid todoId);
        Task UpdateTodoStatusAsync(UpdateTodoStatusDto updateTodoStatusDto);
        Task UpdateTodoPriorityAsync(UpdateTodoPriorityDto updateTodoPriorityDto);
    }
}
