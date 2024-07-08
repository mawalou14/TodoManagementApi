using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoManagementAPI.Application.MappingProfiles;
using TodoManagementAPI.Application.RepoContract;
using TodoManagementAPI.Application.Services.Contracts;
using TodoManagementAPI.Application.Services.Implementations;
using TodoManagementAPI.Domain.DTOs.User;
using TodoManagementAPI.Infrastructure.DataAccess;
using TodoManagementAPI.Infrastructure.RepositoryImplementation;

namespace TodoManagementAPI.Infrastructure.ServiceContainer
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {

            //Add our dbcontext.
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DbConnectionString") ??
                    throw new InvalidOperationException("Sorry, Your connection is not found"));
            });


            // Configure JWT section from appsettings.json
            services.Configure<JwtSection>(configuration.GetSection("JwtSection"));
            var jwtSection = configuration.GetSection(nameof(JwtSection)).Get<JwtSection>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSection!.Issuer,
                    ValidAudience = jwtSection.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.Key!))
                };
            });

            // Add AutoMapper profiles
            services.AddAutoMapper(typeof(TodoMappingProfile));

            // Add Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            // Add Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }


    }
}
