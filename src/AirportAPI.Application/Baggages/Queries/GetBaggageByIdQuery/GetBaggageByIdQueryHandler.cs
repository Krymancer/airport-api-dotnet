using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Airports.Queries.GetAirportById;

public class GetBaggageByIdQueryHandler : IRequestHandler<GetAirportByIdQuery.GetAirportByIdQuery, ErrorOr<Airport>>
{
    private readonly IAirportRepository _airportRepository;

    public GetBaggageByIdQueryHandler(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<ErrorOr<Airport>> Handle(GetAirportByIdQuery.GetAirportByIdQuery request,
        CancellationToken cancellationToken)
    {
        var airport = await _airportRepository.GetByIdAsync(request.AirportId);

        if (airport is null) return Error.NotFound();

        return airport;
    }
}