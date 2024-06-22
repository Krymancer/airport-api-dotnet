using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Tickets.Queries.ListTicketsQuery;

public class ListTicketsQueryHandler : IRequestHandler<ListTicketsQuery, ErrorOr<IEnumerable<Ticket>>>
{
    private readonly ITicketRepository _TicketRepository;

    public ListTicketsQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }

    public async Task<ErrorOr<IEnumerable<Ticket>>> Handle(ListTicketsQuery request,
        CancellationToken cancellationToken)
    {
        var Tickets = await _TicketRepository.ListTickets();

        return ErrorOrFactory.From(Tickets);
    }
}