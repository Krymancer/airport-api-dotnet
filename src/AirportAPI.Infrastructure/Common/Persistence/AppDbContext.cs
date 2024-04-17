using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Persistence;

public class AppDbContext : DbContext, IUnityOfWork
{
    public DbSet<Domain.Entities.Airport> Airports { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<FlightClass> FlightClasses { get; set; } = null!;
    public DbSet<Luggage> Luggage { get; set; } = null!;
    public DbSet<Passenger> Passengers { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}