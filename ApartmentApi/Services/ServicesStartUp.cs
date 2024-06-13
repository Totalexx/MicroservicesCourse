using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Interfaces;

namespace Services;

public static class ServicesStartUp
{
    public static IServiceCollection TryAddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IApartmentService, ApartmentService>();
        serviceCollection.TryAddScoped<ICityService, CityService>();
        return serviceCollection;
    }
}