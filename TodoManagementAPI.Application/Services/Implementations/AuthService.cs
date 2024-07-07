using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoManagementAPI.Application.RepoContract;
using TodoManagementAPI.Application.Services.Contracts;
using TodoManagementAPI.Domain.DTOs.User;
using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMapper _mapper;
        private readonly JwtSection _jwtSettings;

        public AuthService(
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository,
            IMapper mapper,
            IOptions<JwtSection> jwtSettings
            )
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> LoginAsync(Login loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password");
            }

            var authResponse = await GenerateAuthResponse(user);
            return authResponse;
        }

        public async Task<AuthResponse> RegisterAsync(Register registerDto)
        {
            if (await _userRepository.GetUserByEmailAsync(registerDto.Email) != null)
            {
                throw new Exception("User with this email already exists");
            }

            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            await _userRepository.AddAsync(user);

            var authResponse = await GenerateAuthResponse(user);
            return authResponse;
        }

        private async Task<AuthResponse> GenerateAuthResponse(User user)
        {
            var token = GenerateJwtToken(user);
            var refreshToken = await GenerateRefreshToken(user);

            return new AuthResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                User = _mapper.Map<UserProfile>(user)
            };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpiryInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task<string> GenerateRefreshToken(User user)
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                Expires = DateTime.UtcNow.AddDays(_jwtSettings.TokenExpiryInMinutes / 1440), // Converting minutes to days
                Created = DateTime.UtcNow,
                UserId = user.UserId // Use UserId instead of Id for refresh token
            };

            await _refreshTokenRepository.AddAsync(refreshToken);

            return refreshToken.Token;
        }
    }
}
