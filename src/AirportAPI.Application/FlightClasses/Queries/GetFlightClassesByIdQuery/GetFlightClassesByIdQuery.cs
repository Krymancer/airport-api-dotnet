using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Queries.GetFlightClassesByIdQuery;

public record GetFlightClassByIdQuery(Guid FlightClassId) : IRequest<ErrorOr<FlightClass>>;