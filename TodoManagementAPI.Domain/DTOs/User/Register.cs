
using System.ComponentModel.DataAnnotations;

namespace TodoManagementAPI.Domain.DTOs.User
{
    public class Register : AccountBase
    {
        public string? FullName { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Must match with the password above.")]
        public string? ConfirmPassword { get; set; }
    }
}
