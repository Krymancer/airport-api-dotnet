using ErrorOr;
using MediatR;

namespace Application.Airports.Commands.UpdateAirportCommand;

public record UpdateAirportCommand(Guid AirportId, string Name, string IATACode) : IRequest<ErrorOr<Updated>>;