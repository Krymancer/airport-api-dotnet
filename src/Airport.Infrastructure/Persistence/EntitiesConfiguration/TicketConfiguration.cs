using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.Infrastructure.Persistence.EntitiesConfiguration;

public class TicketConfiguration: IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasOne(ticket => ticket.Passenger)
            .WithMany(passenger => passenger.Tickets)
            .HasForeignKey(ticket => ticket.PassengerId);

        builder.HasOne(ticket => ticket.Flight)
            .WithMany(flight => flight.Tickets)
            .HasForeignKey(ticket => ticket.FlightId);

        builder.HasOne(ticket => ticket.Luggage).WithOne(luggage => luggage.Ticket)
            .HasForeignKey<Luggage>(Luggage => Luggage.TicketId);
    }
}