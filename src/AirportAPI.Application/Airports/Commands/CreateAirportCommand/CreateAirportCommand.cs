using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Airports.Commands.CreateAirportCommand;

public record CreateAirportCommand(string IATACode, string Name, Guid CityId) : IRequest<ErrorOr<Airport>>;