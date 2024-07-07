namespace TodoManagementAPI.Domain.DTOs.User
{
    public class AuthResponse
    {
        public string? Token { get; set; }
        public UserProfile? User { get; set; }
    }
}
