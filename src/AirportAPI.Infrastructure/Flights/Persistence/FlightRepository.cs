using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Flights.Persistence;

public class FlightRepository : IFlightRepository
{
    private readonly AppDbContext _context;

    public FlightRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddFlightAsync(Flight flight)
    {
        await _context.Flights.AddAsync(flight);
    }

    public async Task<Flight?> GetByIdAsync(Guid flightId)
    {
        var flight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == flightId);
        return flight;
    }
}