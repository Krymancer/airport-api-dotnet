using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Queries.ListFlightClassesQuery;

public class ListFlightClassesQueryHandler : IRequestHandler<ListFlightClassesQuery, ErrorOr<IEnumerable<FlightClass>>>
{
    private readonly IFlightClassRepository _flightClassRepository;

    public ListFlightClassesQueryHandler(IFlightClassRepository flightClassRepository)
    {
        _flightClassRepository = flightClassRepository;
    }

    public async Task<ErrorOr<IEnumerable<FlightClass>>> Handle(ListFlightClassesQuery request,
        CancellationToken cancellationToken)
    {
        var flightClasss = await _flightClassRepository.FlightClasses();

        return ErrorOrFactory.From(flightClasss);
    }
}