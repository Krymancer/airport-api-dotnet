using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Tickets.Queries.GetTicketById;

public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery.GetTicketByIdQuery, ErrorOr<Ticket>>
{
    private readonly ITicketRepository _TicketRepository;

    public GetTicketByIdQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }

    public async Task<ErrorOr<Ticket>> Handle(GetTicketByIdQuery.GetTicketByIdQuery request,
        CancellationToken cancellationToken)
    {
        var Ticket = await _TicketRepository.GetByIdAsync(request.TicketId);

        if (Ticket is null) return Error.NotFound();

        return Ticket;
    }
}