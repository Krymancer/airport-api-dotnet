using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airport.Infrastructure.Persistence.EntitiesConfiguration;

public class LuggageConfiguration: IEntityTypeConfiguration<Luggage>
{
    public void Configure(EntityTypeBuilder<Luggage> builder)
    {
        builder.HasOne(luggage => luggage.Ticket)
            .WithOne(ticket => ticket.Luggage)
            .HasForeignKey<Luggage>(luggage => luggage.TicketId);
    }
}