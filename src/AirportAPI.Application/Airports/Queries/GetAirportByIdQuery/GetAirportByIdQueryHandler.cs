using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Airports.Queries.GetAirportById;

public class GetAirportByIdQueryHandler : IRequestHandler<GetAirportByIdQuery, ErrorOr<Airport>>
{
    private readonly IAirportRepository _airportRepository;

    public GetAirportByIdQueryHandler(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<ErrorOr<Airport>> Handle(GetAirportByIdQuery request, CancellationToken cancellationToken)
    {
        var airport = await _airportRepository.GetByIdAsync(request.AirportId);

        if (airport is null) return Error.NotFound();

        return airport;
    }
}