using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Passengers.Persistence;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.HasKey(passenger => passenger.Id);

        builder.Property(passenger => passenger.Id)
            .ValueGeneratedNever();

        builder.HasMany(passenger => passenger.Tickets)
            .WithOne(ticket => ticket.Passenger)
            .HasForeignKey(ticket => ticket.PassengerId);
    }
}