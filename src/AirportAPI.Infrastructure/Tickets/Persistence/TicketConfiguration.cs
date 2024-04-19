using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Tickets.Persistence;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(ticket => ticket.Id);

        builder.Property(ticket => ticket.Id)
            .ValueGeneratedNever();

        builder.HasOne(ticket => ticket.Passenger)
            .WithMany(passenger => passenger.Tickets)
            .HasForeignKey(ticket => ticket.PassengerId);

        builder.HasOne(ticket => ticket.Flight)
            .WithMany(flight => flight.Tickets)
            .HasForeignKey(ticket => ticket.FlightId);

        builder.HasOne(ticket => ticket.Luggage).WithOne(luggage => luggage.Ticket)
            .HasForeignKey<Baggage>(baggage => baggage.TicketId);
    }
}