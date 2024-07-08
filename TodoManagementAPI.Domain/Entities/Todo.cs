using TodoManagementAPI.Domain.DTOs.Todo;

namespace TodoManagementAPI.Domain.Entities
{
    public class Todo
    {
        public Guid TodoId { get; set; }
        public string? Description { get; set; }
        public DateTime TargetedTime { get; set; }
        public Priority Priority { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
