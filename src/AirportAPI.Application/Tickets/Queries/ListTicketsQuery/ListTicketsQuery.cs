using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Tickets.Queries.ListTicketsQuery;

public record ListTicketsQuery : IRequest<ErrorOr<IEnumerable<Ticket>>>;