using CodeGardenApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeGardenApi.ApplicationExtensions;

public static class WebApplicationExtensionsMigrateDatabase
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<CodeGardenContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating the database");
        }
    }
}