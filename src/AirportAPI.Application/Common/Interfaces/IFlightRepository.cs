using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IFlightRepository
{
    Task AddFlightAsync(Flight flight);
    Task<Flight?> GetByIdAsync(Guid flightId);
}