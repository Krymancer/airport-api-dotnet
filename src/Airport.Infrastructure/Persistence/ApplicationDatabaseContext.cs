using Airport.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Airport.Domain.Entities;

namespace Airport.Infrastructure.Persistence;

public class ApplicationDatabaseContext : DbContext
{
    public DbSet<Domain.Entities.Airport> Airports { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<FlightClass> FlightClasses { get; set; }
    public DbSet<Luggage> Luggage { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDatabaseContext).Assembly);
    }

    public async Task SaveChangesAsync()
    {
        AddTimestamps();
        await base.SaveChangesAsync(); 
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x is { Entity: BaseEntity, State: EntityState.Added or EntityState.Modified });

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow;
            if (entity.State == EntityState.Added) ((BaseEntity)entity.Entity).CreatedAt = now;
            ((BaseEntity)entity.Entity).UpdatedAt = now;
        }
    }
}