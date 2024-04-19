using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ICityRepository
{
    Task AddCityAsync(City city);
    Task<IEnumerable<City>> ListCities();
    Task<City?> GetByIdAsync(Guid cityId);
    Task RemoveCityAsync(City city);
}