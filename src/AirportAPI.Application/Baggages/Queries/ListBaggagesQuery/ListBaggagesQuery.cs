using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Airports.Queries.ListAirportsQuery;

public record ListBaggagesQuery : IRequest<ErrorOr<IEnumerable<Airport>>>;