using ErrorOr;
using MediatR;

namespace Application.Flights.Commands.DeleteFlight;

public record DeleteFlightCommand(Guid FlightId) : IRequest<ErrorOr<Deleted>>;