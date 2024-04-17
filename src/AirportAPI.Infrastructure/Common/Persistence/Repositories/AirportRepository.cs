using Infrastructure.Common.Persistence.Repositories.Abstractions;
using Infrastructure.Common.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Persistence.Repositories;

public class AirportRepository: BaseRepository<Domain.Entities.Airport>, IAirportRepository
{
    public AirportRepository(DbContext context) : base(context)
    {
    }
}