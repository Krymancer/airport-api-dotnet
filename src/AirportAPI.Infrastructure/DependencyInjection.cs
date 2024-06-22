using Application.Common.Interfaces;
using Infrastructure.Cities.Persistence;
using Infrastructure.Common.Persistence;
using Infrastructure.Flights.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Default")));
        services.AddScoped<IUnityOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<ICityRepository, CityRepository>();

        return services;
    }
}