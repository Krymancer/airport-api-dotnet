using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FlightClasses.Persistence;

public class FlightClassConfiguration : IEntityTypeConfiguration<FlightClass>
{
    public void Configure(EntityTypeBuilder<FlightClass> builder)
    {
        builder.HasKey(flightClass => flightClass.Id);

        builder.Property(flightClass => flightClass.Id)
            .ValueGeneratedNever();

        builder.Property(flightClass => flightClass.Class)
            .HasConversion(
                flightClass => flightClass.Value,
                flightClass => FlightClassesEnum.FromValue(flightClass)
            );

        builder.HasOne(flightClass => flightClass.Flight)
            .WithMany(flight => flight.FlightClasses)
            .HasForeignKey(flightClass => flightClass.FlightId);
    }
}