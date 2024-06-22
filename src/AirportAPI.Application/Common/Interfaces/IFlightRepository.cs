using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> ListFlights();
    Task AddFlightAsync(Flight flight);
    Task<Flight?> GetByIdAsync(Guid flightId);
    Task UpdateFlightAsync(Flight flight);
    Task RemoveFlightAsync(Flight flight);
}