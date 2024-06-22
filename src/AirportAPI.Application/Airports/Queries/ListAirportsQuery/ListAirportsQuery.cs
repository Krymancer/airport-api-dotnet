using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Airports.Queries.ListAirportsQuery;

public record ListAirportsQuery : IRequest<ErrorOr<IEnumerable<Airport>>>;