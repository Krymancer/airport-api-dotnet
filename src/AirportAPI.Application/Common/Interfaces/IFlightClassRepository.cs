using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IFlightClassRepository
{
    Task AddFlightClassAsync(FlightClass flightClass);
    Task<IEnumerable<FlightClass>> FlightClasses();
    Task<FlightClass?> GetByIdAsync(Guid flightClassId);
    Task RemoveFlightClassAsync(FlightClass flightClass);
    Task UpdateFlightClassAsync(FlightClass flightClass);
}