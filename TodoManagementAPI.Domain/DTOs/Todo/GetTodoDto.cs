namespace TodoManagementAPI.Domain.DTOs.Todo
{
    public class GetTodoDto
    {
        public Guid TodoId { get; set; }
        public string? Description { get; set; }
        public DateTime TargetedTime { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
