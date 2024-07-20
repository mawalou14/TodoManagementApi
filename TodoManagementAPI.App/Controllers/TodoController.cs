using Microsoft.AspNetCore.Authorization;
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
                var createdResult = await _todoService.CreateTodoAsync(createTodoDto);
            if(createdResult.Flag)
            {
                return Ok(createdResult.Message);
            } else
            {
                return BadRequest(createdResult.Message);
            }
                
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoDto updateTodoDto)
        {
              var updatedResult = await _todoService.UpdateTodoAsync(updateTodoDto);
            if (updatedResult.Flag)
            {
                return Ok(updatedResult.Message);
            }
            else
            {
                return BadRequest(updatedResult.Message);
            }
        }

        [HttpDelete("delete/{todoId}")]
        public async Task<IActionResult> DeleteTodo(Guid todoId)
        {
               var deletedResult = await _todoService.DeleteTodoAsync(todoId);
            if (deletedResult.Flag)
            {
                return Ok(deletedResult.Message);
            }
            else
            {
                return BadRequest(deletedResult.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
                var todo = await _todoService.GetTodoByIdAsync(id);
                return Ok(todo);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserTodos(Guid userId)
        {
                var todos = await _todoService.GetUserTodosAsync(userId);
                return Ok(todos);
        }

        [HttpPatch("update-status")]
        public async Task<IActionResult> UpdateTodoStatus([FromBody] UpdateTodoStatusDto updateTodoStatusDto)
        {
                var updatedTodoResult = await _todoService.UpdateTodoStatusAsync(updateTodoStatusDto);
            if (updatedTodoResult.Flag)
            {
                return Ok(updatedTodoResult.Message);
            }
            else
            {
                return BadRequest(updatedTodoResult.Message);
            }
        }

        [HttpPatch("update-priority")]
        public async Task<IActionResult> UpdateTodoPriority([FromBody] UpdateTodoPriorityDto updateTodoPriorityDto)
        {
                var updatedTodoResult = await _todoService.UpdateTodoPriorityAsync(updateTodoPriorityDto);
            if (updatedTodoResult.Flag)
            {
                return Ok(updatedTodoResult.Message);
            }
            else
            {
                return BadRequest(updatedTodoResult.Message);
            }
        }
    }
}
