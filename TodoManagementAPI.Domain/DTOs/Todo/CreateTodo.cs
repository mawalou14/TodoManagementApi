namespace TodoManagementAPI.Domain.DTOs.Todo
{
    public class CreateTodoDto : TodoDto 
    {
        public Guid UserId { get; set; }
    }
}
