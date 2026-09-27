namespace Minimal2;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddScoped<ProductRetrievalService>();
        services.AddSingleton<DeliveryDateBookingService>();
        services.AddScoped<OrderRetrievalService>();
        services.AddSingleton<OrderRepository>();
        
        return services;
    }
}