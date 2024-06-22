using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cities.Persistence;

public class CityRepository : ICityRepository
{
    private readonly AppDbContext _context;

    public CityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddCityAsync(City city)
    {
        await _context.Cities.AddAsync(city);
    }

    public async Task<IEnumerable<City>> ListCities()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task<City?> GetByIdAsync(Guid cityId)
    {
        return await _context.Cities.FirstOrDefaultAsync(city => city.Id == cityId);
    }

    public Task UpdateCityAsync(City city)
    {
        _context.Cities.Update(city);
        return Task.CompletedTask;
    }

    public Task RemoveCityAsync(City city)
    {
        _context.Cities.Remove(city);
        return Task.CompletedTask;
    }
}