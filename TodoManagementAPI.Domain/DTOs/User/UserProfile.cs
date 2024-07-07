namespace TodoManagementAPI.Domain.DTOs.User
{
    public class UserProfile
    {
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
