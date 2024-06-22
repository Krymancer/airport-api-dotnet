using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Queries.ListFlightClassesQuery;

public record ListFlightClassesQuery : IRequest<ErrorOr<IEnumerable<FlightClass>>>;