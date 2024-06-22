using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IPassengerRepository
{
    Task AddPassengerAsync(Passenger passenger);
    Task<IEnumerable<Passenger>> ListPassengers();
    Task<Passenger?> GetByIdAsync(Guid passengerId);
    Task UpdatePassengerAsync(Passenger passenger);
    Task RemovePassengerAsync(Passenger passenger);
}