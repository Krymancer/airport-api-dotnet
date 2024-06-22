using ErrorOr;
using MediatR;

namespace Application.Flights.Commands.UpdateFlight;

public record UpdateFlightCommand(Guid FlightId) : IRequest<ErrorOr<Updated>>;