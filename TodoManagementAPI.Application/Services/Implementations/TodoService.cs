using AutoMapper;
using TodoManagementAPI.Application.RepoContract;
using TodoManagementAPI.Application.Services.Contracts;
using TodoManagementAPI.Domain.DTOs.Todo;
using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Application.Services.Implementations
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;

        public TodoService(ITodoRepository todoRepository, IMapper mapper, IUserRepository userRepository)
        {
            this._todoRepository = todoRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task CreateTodoAsync(CreateTodoDto createTodoDto)
        {
            var todo = _mapper.Map<Todo>(createTodoDto);
            await _todoRepository.AddAsync(todo);
        }

        public async Task UpdateTodoAsync(UpdateTodoDto updateTodoDto)
        {
            var existingTodo = await _todoRepository.GetByIdAsync(updateTodoDto.TodoId);

            if (existingTodo == null)
            {
                throw new Exception("Todo not found.");
            }

            _mapper.Map(updateTodoDto, existingTodo);

            await _todoRepository.UpdateAsync(existingTodo);
        }

        public async Task DeleteTodoAsync(Guid todoId)
        {
            var existingTodo = await _todoRepository.GetByIdAsync(todoId);

            if (existingTodo == null)
            {
                throw new Exception("Todo not found.");
            }

            await _todoRepository.DeleteAsync(existingTodo);
        }

        public async Task<TodoDto> GetTodoByIdAsync(Guid todoId)
        {
            var todo = await _todoRepository.GetByIdAsync(todoId);

            if (todo == null)
            {
                throw new Exception("Todo not found.");
            }

            return _mapper.Map<TodoDto>(todo);
        }
        public async Task<List<GetTodoDto>> GetUserTodosAsync(Guid userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("The user is not found.");
            }

            var todos = await _todoRepository.GetTodosByUserIdAsync(userId);
            return _mapper.Map<List<GetTodoDto>>(todos);
        }

        public async Task UpdateTodoStatusAsync(UpdateTodoStatusDto updateTodoStatusDto)
        {
            var todo = await _todoRepository.GetByIdAsync(updateTodoStatusDto.TodoId);
            if (todo == null)
            {
                throw new Exception("Todo not found");
            }
            todo.Status = updateTodoStatusDto.Status;
            await _todoRepository.UpdateAsync(todo);
        }

        public async Task UpdateTodoPriorityAsync(UpdateTodoPriorityDto updateTodoPriorityDto)
        {
            var todo = await _todoRepository.GetByIdAsync(updateTodoPriorityDto.TodoId);
            if (todo == null)
            {
                throw new Exception("Todo not found");
            }
            todo.Priority = updateTodoPriorityDto.Priority;
            await _todoRepository.UpdateAsync(todo);
        }
    }
}
