using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Flights.Queries.GetFlight;

public record GetFlightQuery(Guid FlightId): IRequest<ErrorOr<Flight>>;