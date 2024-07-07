using System.ComponentModel.DataAnnotations;

namespace TodoManagementAPI.Domain.DTOs.User
{
    public class ChangePassword
    {
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessage = "Must match with the new password above.")]
        public string? ConfirmNewPassword { get; set; }
    }
}
