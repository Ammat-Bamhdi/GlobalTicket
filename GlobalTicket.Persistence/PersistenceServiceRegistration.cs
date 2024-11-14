using GlobalTicket.Application.Contracts.Persistence;
using GlobalTicket.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalTicket.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<GlobalTicketDbContext>(options =>
            options.UseOracle(configuration.GetConnectionString("GlobalTicketManagementConnectionString"))); 
        
        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>(); 
        
        return services;
        
        // 
    }
}