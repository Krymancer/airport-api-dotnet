using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.Infrastructure.Persistence.EntitiesConfiguration;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasOne(flight => flight.OriginAirport)
            .WithOne()
            .HasForeignKey<Flight>(flight => flight.OriginAirport);

        builder.HasOne(flight => flight.DestinationAirport)
            .WithOne()
            .HasForeignKey<Flight>(flight => flight.DestinationAirport);

        builder.HasMany(flight => flight.Tickets)
            .WithOne(ticket => ticket.Flight);

        builder.HasMany(flight => flight.FlightClasses)
            .WithOne(flightClass => flightClass.Flight);
    }
}