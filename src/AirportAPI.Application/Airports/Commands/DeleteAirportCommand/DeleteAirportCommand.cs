using ErrorOr;
using MediatR;

namespace Application.Airports.Commands.DeleteAirportCommand;

public record DeleteAirportCommand(Guid AirportId) : IRequest<ErrorOr<Deleted>>;