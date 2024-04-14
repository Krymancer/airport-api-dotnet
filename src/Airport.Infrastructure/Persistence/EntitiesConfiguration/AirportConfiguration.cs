using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.Infrastructure.Persistence.EntitiesConfiguration;

public class AirportConfiguration : IEntityTypeConfiguration<Domain.Entities.Airport>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Airport> builder)
    {
        builder.HasOne(airport => airport.City)
            .WithMany(city => city.Airports)
            .HasForeignKey(airport => airport.CityId);
    }
}