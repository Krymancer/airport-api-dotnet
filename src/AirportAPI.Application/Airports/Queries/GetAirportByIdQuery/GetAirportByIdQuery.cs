using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Airports.Queries.GetAirportByIdQuery;

public record GetAirportByIdQuery(Guid AirportId) : IRequest<ErrorOr<Airport>>;