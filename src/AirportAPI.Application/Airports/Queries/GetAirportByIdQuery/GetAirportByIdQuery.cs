using Domain.Entities;
using ErrorOr;
using MediatR;

public record GetAirportByIdQuery(Guid AirportId) : IRequest<ErrorOr<Airport>>;