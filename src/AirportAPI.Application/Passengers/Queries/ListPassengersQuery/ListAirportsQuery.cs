using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Passengers.Queries.ListPassengersQuery;

public record ListPassengersQuery : IRequest<ErrorOr<IEnumerable<Passenger>>>;