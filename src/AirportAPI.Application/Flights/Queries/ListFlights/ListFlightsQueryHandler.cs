using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Flights.Queries.ListFlights;

public class ListFlightsQueryHandler: IRequestHandler<ListFlightsQuery, ErrorOr<IEnumerable<Flight>>>
{
    private readonly IFlightRepository _flightRepository;

    public ListFlightsQueryHandler(IFlightRepository FlightRepository)
    {
        _flightRepository = FlightRepository;
    }

    public async Task<ErrorOr<IEnumerable<Flight>>> Handle(ListFlightsQuery request, CancellationToken cancellationToken)
    {
        var fligths = await _flightRepository.ListFlights();

        return ErrorOrFactory.From(fligths);
    }
}