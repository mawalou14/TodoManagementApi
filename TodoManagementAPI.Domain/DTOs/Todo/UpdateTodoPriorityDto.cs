namespace TodoManagementAPI.Domain.DTOs.Todo
{
    public class UpdateTodoPriorityDto
    {
        public Guid TodoId { get; set; }
        public int Priority { get; set; }
    }
}
