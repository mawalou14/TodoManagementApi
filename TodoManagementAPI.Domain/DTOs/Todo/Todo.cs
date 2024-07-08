namespace TodoManagementAPI.Domain.DTOs.Todo
{
    public class Todo
    {
        public string? Description { get; set; }
        public DateTime TargetedTime { get; set; }
        public Priority Priority { get; set; }
        public int Status { get; set; }
    }
}
