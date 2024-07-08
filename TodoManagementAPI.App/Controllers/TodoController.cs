using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoManagementAPI.Application.Services.Contracts;
using TodoManagementAPI.Domain.DTOs.Todo;

namespace TodoManagementAPI.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoDto createTodoDto)
        {
            try
            {
                await _todoService.CreateTodoAsync(createTodoDto);
                return Ok("Todo created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoDto updateTodoDto)
        {
            try
            {
                await _todoService.UpdateTodoAsync(updateTodoDto);
                return Ok("Todo updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete/{todoId}")]
        public async Task<IActionResult> DeleteTodo(Guid todoId)
        {
            try
            {
                await _todoService.DeleteTodoAsync(todoId);
                return Ok("Todo deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            try
            {
                var todo = await _todoService.GetTodoByIdAsync(id);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserTodos(Guid userId)
        {
            try
            {
                var todos = await _todoService.GetUserTodosAsync(userId);
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPatch("update-status")]
        public async Task<IActionResult> UpdateTodoStatus([FromBody] UpdateTodoStatusDto updateTodoStatusDto)
        {
            try
            {
                await _todoService.UpdateTodoStatusAsync(updateTodoStatusDto);
                return Ok("Todo status updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPatch("update-priority")]
        public async Task<IActionResult> UpdateTodoPriority([FromBody] UpdateTodoPriorityDto updateTodoPriorityDto)
        {
            try
            {
                await _todoService.UpdateTodoPriorityAsync(updateTodoPriorityDto);
                return Ok("Todo priority updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
