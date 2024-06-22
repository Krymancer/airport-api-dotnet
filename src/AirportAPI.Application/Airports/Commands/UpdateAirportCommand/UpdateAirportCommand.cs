using ErrorOr;
using MediatR;

public record UpdateAirportCommand(Guid AirportId, string Name, string IATACode) : IRequest<ErrorOr<Updated>>;