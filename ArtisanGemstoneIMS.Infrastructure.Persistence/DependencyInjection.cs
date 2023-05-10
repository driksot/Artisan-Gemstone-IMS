using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtisanGemstoneIMS.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IMSDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AGInventoryManagement"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
