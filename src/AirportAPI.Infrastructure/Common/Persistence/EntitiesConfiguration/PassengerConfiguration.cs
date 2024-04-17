using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Common.Persistence.EntitiesConfiguration;

public class PassengerConfiguration: IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.HasMany(passenger => passenger.Tickets)
            .WithOne(ticket => ticket.Passenger)
            .HasForeignKey(ticket => ticket.PassengerId);
    }
}