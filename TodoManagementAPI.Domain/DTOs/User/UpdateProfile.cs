namespace TodoManagementAPI.Domain.DTOs.User
{
    public class UpdateProfile
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
