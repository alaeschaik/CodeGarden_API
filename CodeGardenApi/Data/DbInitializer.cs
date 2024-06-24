using CodeGardenApi.Models;

namespace CodeGardenApi.Data;

public static class DbInitializer
{
    public static void Initialize(CodeGardenContext context)
    {
        context.Database.EnsureCreated();

        // Check if data already exists
        if (context.Modules.Any())
        {
            return; // DB has been seeded
        }

        var modules = new[]
        {
            new Module
            {
                Title = "Test Module 1",
                Description = "Test Module 1 Description",
                Introduction = "Test Module 1 Introduction",
                Sections = [],
                Content = string.Empty,
                TotalXpPoints = 0.0m
            }
        };

        context.Modules.AddRange(modules);
        context.SaveChanges();
    }
}
