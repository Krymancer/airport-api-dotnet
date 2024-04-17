using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Airports.Persistence;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasKey(airport => airport.Id);

        builder.Property(airport => airport.Id)
            .ValueGeneratedNever();

        builder.HasOne(airport => airport.City)
            .WithMany(city => city.Airports)
            .HasForeignKey(airport => airport.CityId);
    }
}