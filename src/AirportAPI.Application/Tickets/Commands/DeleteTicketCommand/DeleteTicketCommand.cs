using ErrorOr;
using MediatR;

namespace Application.Tickets.Commands.DeleteTicketCommand;

public record DeleteTicketCommand(Guid TicketId) : IRequest<ErrorOr<Deleted>>;