using ProvaPub.Interfaces.Repository;
using ProvaPub.Interfaces.Services;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfig(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IRandomService, RandomService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICustomerService, CustomerService>();
        // Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}