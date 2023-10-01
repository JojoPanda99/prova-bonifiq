namespace ProvaPub.Configuration;

public static class SwaggerConfig
{
    public static void UseSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen();
    }

    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}