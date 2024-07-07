using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoManagementAPI.Application.MappingProfiles;
using TodoManagementAPI.Domain.DTOs.User;
using TodoManagementAPI.Infrastructure.DataAccess;

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


            var key = Encoding.ASCII.GetBytes(jwtSection.Secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSection.Issuer,
                    ValidAudience = jwtSection.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Add AutoMapper profiles
            services.AddAutoMapper(typeof(TodoMappingProfile));

            return services;
        }


    }
}
