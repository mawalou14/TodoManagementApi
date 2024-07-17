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

        public async Task<GeneralResponse> CreateTodoAsync(CreateTodoDto createTodoDto)
        {
            if (createTodoDto == null) return new GeneralResponse(false, "Please Provide a valid Todo");
            var user = await userRepository.GetUserByIdAsync(createTodoDto.UserId);
            if (user == null)
            {
                return new GeneralResponse(false, "Invalid User");
            }
            var todo = _mapper.Map<Todo>(createTodoDto);
            var createdTodo = await _todoRepository.AddAsync(todo);
            if (createdTodo == null) return new GeneralResponse(false, "Error While Creating The Todo");
            return new GeneralResponse(true, "Todo Created SuccessFully");
        }

        public async Task<GeneralResponse> UpdateTodoAsync(UpdateTodoDto updateTodoDto)
        {
            if (updateTodoDto == null) return new GeneralResponse(false, "Please Provide a valid Todo");
            var existingTodo = await _todoRepository.GetByIdAsync(updateTodoDto.TodoId);

            if (existingTodo == null)
            {
                return new GeneralResponse(false, "Todo Provided is not found");
            }

            _mapper.Map(updateTodoDto, existingTodo);

            var updatedTodo = await _todoRepository.UpdateAsync(existingTodo);
            if (updatedTodo == null) return new GeneralResponse(false, "Error While Updating The Todo");
            return new GeneralResponse(true, "Todo Updated SuccessFully");
        }

        public async Task<GeneralResponse> DeleteTodoAsync(Guid todoId)
        {
            var existingTodo = await _todoRepository.GetByIdAsync(todoId);

            if (existingTodo == null)
            {
                return new GeneralResponse(false, "Todo Provided is not found");
            }

            var deletedTodo = await _todoRepository.DeleteAsync(existingTodo);
            if (deletedTodo == null) return new GeneralResponse(false, "Error While Deleting The Todo");
            return new GeneralResponse(true, "Todo Deleted SuccessFully");
        }

        public async Task<TodoDto> GetTodoByIdAsync(Guid todoId)
        {
            var todo = await _todoRepository.GetByIdAsync(todoId);

            if (todo == null)
            {
                return null;
            }

            return _mapper.Map<TodoDto>(todo);
        }
        public async Task<List<GetTodoDto>> GetUserTodosAsync(Guid userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var todos = await _todoRepository.GetTodosByUserIdAsync(userId);
            return _mapper.Map<List<GetTodoDto>>(todos);
        }

        public async Task<GeneralResponse> UpdateTodoStatusAsync(UpdateTodoStatusDto updateTodoStatusDto)
        {
            var todo = await _todoRepository.GetByIdAsync(updateTodoStatusDto.TodoId);
            if (todo == null)
            {
                return new GeneralResponse(false, "Todo Provided is not found");
            }
            todo.Status = updateTodoStatusDto.Status;
            var updatedTodo = await _todoRepository.UpdateAsync(todo);
            if (updatedTodo == null) return new GeneralResponse(false, "Error While Updating the status of this Todo");
            return new GeneralResponse(true, "Todo Status Updated SuccessFully");
        }

        public async Task<GeneralResponse> UpdateTodoPriorityAsync(UpdateTodoPriorityDto updateTodoPriorityDto)
        {
            var todo = await _todoRepository.GetByIdAsync(updateTodoPriorityDto.TodoId);
            if (todo == null)
            {
                return new GeneralResponse(false, "Todo Provided is not found");
            }
            todo.Priority = updateTodoPriorityDto.Priority;
            var updatedTodo = await _todoRepository.UpdateAsync(todo);
            if (updatedTodo == null) return new GeneralResponse(false, "Error While Updating the priority of this Todo");
            return new GeneralResponse(true, "Todo Priority Updated SuccessFully");
        }
    }
}
