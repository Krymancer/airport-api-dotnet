using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Flights.Persistence;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasKey(flight => flight.Id);

        builder.Property(flight => flight.Id)
            .ValueGeneratedNever();
        
        builder.HasOne(flight => flight.OriginAirport)
            .WithOne()
            .HasForeignKey<Flight>(flight => flight.OriginAirportId);

        builder.HasOne(flight => flight.DestinationAirport)
            .WithOne()
            .HasForeignKey<Flight>(flight => flight.DestinationAirportId);

        builder.HasMany(flight => flight.Tickets)
            .WithOne(ticket => ticket.Flight);

        builder.HasMany(flight => flight.FlightClasses)
            .WithOne(flightClass => flightClass.Flight);
    }
}