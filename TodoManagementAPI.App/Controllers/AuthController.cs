using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoManagementAPI.Application.Services.Contracts;
using TodoManagementAPI.Domain.DTOs.User;

namespace TodoManagementAPI.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Register registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Token = result.Token, RefreshToken = result.RefreshToken, User = result.User });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);

            if (!result.Success)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(new { Token = result.Token, RefreshToken = result.RefreshToken, User = result.User });
        }
    }
}

