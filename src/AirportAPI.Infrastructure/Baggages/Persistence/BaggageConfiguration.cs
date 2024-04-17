using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Baggages.Persistence;

public class BaggageConfiguration : IEntityTypeConfiguration<Baggage>
{
    public void Configure(EntityTypeBuilder<Baggage> builder)
    {
        builder.HasKey(baggage => baggage.Id);

        builder.Property(baggage => baggage.Id)
            .ValueGeneratedNever();

        builder.HasOne(baggage => baggage.Ticket)
            .WithOne(ticket => ticket.Luggage)
            .HasForeignKey<Baggage>(baggage => baggage.TicketId);
    }
}