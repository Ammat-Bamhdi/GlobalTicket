using GlobalTicket.Application;
using GlobalTicket.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.Api;

public static  class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Register application services
        builder.Services.AddApplicationServices();

        // Register persistence services with configuration
        builder.Services.AddPersistenceServices(builder.Configuration);

        // Add controllers for handling API requests
        builder.Services.AddControllers();

        // Configure CORS policy named "Open" allowing all origins, headers, and methods
        builder.Services.AddCors(options => options.AddPolicy(
            "Open",
            policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

        // Build the WebApplication instance
        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline
        (this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("Open");
        app.MapControllers();
        return app;
    }

    public static async Task RestDatabaseAsync(this WebApplication app)
    {
        // Create a temporary service container to access the database context
        using var scope = app.Services.CreateScope();

        try
        {
            // Get the database context service from the container
            var context = scope.ServiceProvider.GetService<GlobalTicketDbContext>();

            // If the context is available (meaning database is configured)
            if (context != null)
            {
                // Ensure the database schema is created if it doesn't exist
                await context.Database.EnsureCreatedAsync();

                // Apply any pending database migrations (updates to schema)
                await context.Database.MigrateAsync();
            }
        }
        catch (Exception e)
        {
            // Handle any exceptions during database operations (add logging here)
        }
    }
}