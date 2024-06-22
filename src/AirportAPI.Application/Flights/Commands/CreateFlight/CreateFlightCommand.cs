using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Flights.Commands.CreateFlight;

public record CreateFlightCommand(
    string FlightNumber,
    Guid OriginAirport,
    Guid DestinationAirport,
    DateTime Departure,
    DateTime Arrival) : IRequest<ErrorOr<Flight>>;