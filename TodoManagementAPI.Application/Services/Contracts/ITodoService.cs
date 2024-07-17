using TodoManagementAPI.Domain.DTOs.Todo;

namespace TodoManagementAPI.Application.Services.Contracts
{
    public interface ITodoService
    {
        Task<GeneralResponse> CreateTodoAsync(CreateTodoDto createTodoDto);
        Task<GeneralResponse> UpdateTodoAsync(UpdateTodoDto updateTodoDto);
        Task<GeneralResponse> DeleteTodoAsync(Guid todoId);
        Task<List<GetTodoDto>> GetUserTodosAsync(Guid userId);
        Task<TodoDto> GetTodoByIdAsync(Guid todoId);
        Task<GeneralResponse> UpdateTodoStatusAsync(UpdateTodoStatusDto updateTodoStatusDto);
        Task<GeneralResponse> UpdateTodoPriorityAsync(UpdateTodoPriorityDto updateTodoPriorityDto);
    }
}
