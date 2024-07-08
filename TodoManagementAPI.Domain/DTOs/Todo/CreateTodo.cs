namespace TodoManagementAPI.Domain.DTOs.Todo
{
    public class CreateTodo : Todo
    {
        public Guid UserId { get; set; }
    }
}
