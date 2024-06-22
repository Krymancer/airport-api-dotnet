using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Flights.Queries.GetFlightById;

public record GetFlightByIdQuery(Guid FlightId) : IRequest<ErrorOr<Flight>>;