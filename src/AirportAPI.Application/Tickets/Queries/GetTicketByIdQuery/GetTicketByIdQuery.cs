using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Tickets.Queries.GetTicketByIdQuery;

public record GetTicketByIdQuery(Guid TicketId) : IRequest<ErrorOr<Ticket>>;