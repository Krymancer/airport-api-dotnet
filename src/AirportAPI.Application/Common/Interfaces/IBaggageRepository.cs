using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IBaggageRepository
{
    Task AddBaggageAsync(Baggage baggage);
    Task<IEnumerable<Baggage>> ListBaggages();
    Task<Baggage?> GetByIdAsync(Guid baggageId);
    Task UpdateBaggageAsync(Baggage baggage);
    Task RemoveBaggageAsync(Baggage baggage);
}