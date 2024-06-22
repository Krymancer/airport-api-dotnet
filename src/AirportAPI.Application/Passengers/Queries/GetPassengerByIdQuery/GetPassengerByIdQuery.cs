using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Passengers.Queries.GetPassengerByIdQuery;

public record GetPassengerByIdQuery(Guid PassengerId) : IRequest<ErrorOr<Passenger>>;