
using TodoManagementAPI.Domain.DTOs.User;

namespace TodoManagementAPI.Application.Services.Contracts
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(Login loginDto);
        Task<AuthResponse> RegisterAsync(Register registerDto);
    }
}
