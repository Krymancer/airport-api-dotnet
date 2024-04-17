using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Flights.Persistence;

public class FlightRepository : IFlightRepository
{
    private static readonly AppDbContext _context;

    public async Task AddFlightAsync(Flight flight)
    {
        await _context.Flights.AddAsync(flight);
        await _context.SaveChangesAsync();
    }

    public async Task<Flight?> GetByIdAsync(Guid flightId)
    {
        var flight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == flightId);
        return flight;
    }
}