using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.Infrastructure.Persistence.EntitiesConfiguration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasMany(city => city.Airports)
            .WithOne(airport => airport.City);
    }
}