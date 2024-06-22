using Domain.Entities;
using ErrorOr;
using MediatR;

public record GetBaggageByIdQuery(Guid AirportId) : IRequest<ErrorOr<Airport>>;