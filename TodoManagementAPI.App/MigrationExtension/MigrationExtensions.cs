using Microsoft.EntityFrameworkCore;
using TodoManagementAPI.Infrastructure.DataAccess;

namespace TodoManagementAPI.App.MigrationExtension
{

    public static class MigrationExtensions
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using AppDbContext dbcontext =
                scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbcontext.Database.Migrate();
        }
    }
}
