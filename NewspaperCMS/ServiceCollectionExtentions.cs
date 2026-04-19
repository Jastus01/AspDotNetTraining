using NewspaperCMS.Services;

namespace NewspaperCMS;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        services.AddScoped<INewspaperService, NewspaperService>();

        return services;
    }
}