using Airport.Infrastructure.Persistence.Repositories.Abstractions;
using Airport.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Airport.Infrastructure.Persistence.Repositories;

public class AirportRepository: BaseRepository<Domain.Entities.Airport>, IAirportRepository
{
    public AirportRepository(DbContext context) : base(context)
    {
    }
}