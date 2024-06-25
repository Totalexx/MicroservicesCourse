using Domain.Interfaces;
using Infastructed.Connections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProfileDal.Data;

namespace Infastructed;

public static class InfrastructureStartUp
{
    public static IServiceCollection TryAddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<ICheckUser, CheckUser>();
        serviceCollection.TryAddScoped<IAddressRepository, AddressRepository>();
        serviceCollection.TryAddScoped<ICityRepository, CityRepository>();
        serviceCollection.TryAddScoped<IApartmentRepository, ApartmentRepository>();
        return serviceCollection;
    }
}