using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Persistence;

public class AppDbContext : DbContext, IUnityOfWork
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Airport> Airports { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<FlightClass> FlightClasses { get; set; } = null!;
    public DbSet<Baggage> Luggage { get; set; } = null!;
    public DbSet<Passenger> Passengers { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}