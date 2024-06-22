using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IAirportRepository
{
    Task AddAirportAsync(Airport airpot);
    Task<IEnumerable<Airport>> ListAirports();
    Task<Airport?> GetByIdAsync(Guid airpotId);
    Task UpdateAirportAsync(Airport airpot);
    Task RemoveAirportAsync(Airport airpot);
}