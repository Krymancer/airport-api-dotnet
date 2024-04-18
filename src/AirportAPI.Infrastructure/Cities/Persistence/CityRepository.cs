using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Cities.Persistence;

public class CityRepository: ICityRepository
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

    public async Task<IEnumerable<City>> GetAll()
    {
        return await _context.Cities.ToListAsync();
    }
}