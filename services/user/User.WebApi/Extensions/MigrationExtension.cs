using User.Infrastructure;
using Microsoft.EntityFrameworkCore;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();

        ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
}