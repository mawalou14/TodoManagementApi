namespace TodoManagementAPI.Domain.DTOs.Todo
{
    public class UpdateTodoStatusDto
    {
        public Guid TodoId { get; set; }
        public int Status { get; set; }
    }
}
