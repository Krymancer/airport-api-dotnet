using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Airports.Queries.ListAirportsQuery;

public class ListBaggagesQueryHandler : IRequestHandler<ListAirportsQuery, ErrorOr<IEnumerable<Airport>>>
{
    private readonly IAirportRepository _airportRepository;

    public ListBaggagesQueryHandler(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<ErrorOr<IEnumerable<Airport>>> Handle(ListAirportsQuery request,
        CancellationToken cancellationToken)
    {
        var airports = await _airportRepository.ListAirports();

        return ErrorOrFactory.From(airports);
    }
}