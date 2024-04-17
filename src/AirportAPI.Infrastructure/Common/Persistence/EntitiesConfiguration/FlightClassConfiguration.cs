using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Common.Persistence.EntitiesConfiguration;

public class FlightClassConfiguration: IEntityTypeConfiguration<FlightClass>
{
    public void Configure(EntityTypeBuilder<FlightClass> builder)
    {
        builder.HasOne(flightClass => flightClass.Flight)
            .WithMany(flight => flight.FlightClasses)
            .HasForeignKey(flightClass => flightClass.FlightId);
    }
}