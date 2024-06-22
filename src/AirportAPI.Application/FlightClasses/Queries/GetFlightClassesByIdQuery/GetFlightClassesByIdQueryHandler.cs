using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Queries.GetFlightClassesByIdQuery;

public class GetFlightClassByIdQueryHandler : IRequestHandler<GetFlightClassByIdQuery, ErrorOr<FlightClass>>
{
    private readonly IFlightClassesRepository _airportRepository;

    public GetFlightClassByIdQueryHandler(IFlightClassesRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<ErrorOr<FlightClass>> Handle(GetFlightClassByIdQuery request, CancellationToken cancellationToken)
    {
        var airport = await _airportRepository.GetByIdAsync(request.FlightClassId);

        if (airport is null) return Error.NotFound();

        return airport;
    }
}