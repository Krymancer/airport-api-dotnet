using Airport.Infrastructure.Persistence.Repositories.Abstractions;

namespace Application.Services;

public class AirportService
{
    private readonly IAirportRepository _airportRepository;

    public AirportService(IAirportRepository repository)
    {
        _airportRepository = repository;
    }

    public async Task<IEnumerable<Airport.Domain.Entities.Airport>> GetAll()
    {
        return await _airportRepository.GetAsync();
    }
}