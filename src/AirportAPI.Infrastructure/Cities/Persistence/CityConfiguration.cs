using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Cities.Persistence;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(city => city.Id);

        builder.Property(city => city.Id)
            .ValueGeneratedNever();

        builder.HasMany(city => city.Airports)
            .WithOne(airport => airport.City)
            .HasForeignKey(airport => airport.CityId);
    }
}