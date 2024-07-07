
using TodoManagementAPI.Domain.DTOs.User;

namespace TodoManagementAPI.Application.Services.Contracts
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(Register registerDto);
        Task<AuthResponse> LoginAsync(Login loginDto);
    }
}
