using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Flights.Queries.GetFlight;

public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, ErrorOr<Flight>>
{
    private readonly IFlightRepository _flightRepository;

    public GetFlightQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<ErrorOr<Flight>> Handle(GetFlightQuery request, CancellationToken cancellationToken)
    {
        var flight = await _flightRepository.GetByIdAsync(request.FlightId);

        if (flight is null) return Error.NotFound("Fight Not Found");

        return flight;
    }
}