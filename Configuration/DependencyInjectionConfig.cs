using ProvaPub.Interfaces.Repository;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfig(this IServiceCollection services)
    {
        services.AddScoped<RandomService>();
        services.AddScoped<ProductService>();
        services.AddScoped<CustomerService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}