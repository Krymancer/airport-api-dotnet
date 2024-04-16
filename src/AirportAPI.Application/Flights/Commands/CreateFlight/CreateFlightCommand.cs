using ErrorOr;
using MediatR;

namespace Application.Flights.Commands.CreateFlight;

public record CreateFlightCommand(
    string OriginIATACode,
    string DestinationIATACode,
    DateTime Departure,
    DateTime Arrival) : IRequest<ErrorOr<string>>;