using Domain.Entities;
using ErrorOr;

namespace Application.Common.Interfaces;

public interface IFlightRepository
{ 
    Task AddFlightAsync(Flight flight);
    Task<Flight?> GetByIdAsync(Guid flightId);
}