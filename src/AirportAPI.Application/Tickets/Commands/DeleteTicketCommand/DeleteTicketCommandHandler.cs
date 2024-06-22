using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand.DeleteTicketCommand, ErrorOr<Deleted>>
{
    private readonly ITicketRepository _TicketRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteTicketCommandHandler(ITicketRepository TicketRepository, IUnityOfWork unityOfWork)
    {
        _TicketRepository = TicketRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteTicketCommand.DeleteTicketCommand request,
        CancellationToken cancellationToken)
    {
        var Ticket = await _TicketRepository.GetByIdAsync(request.TicketId);

        if (Ticket is null) return Error.NotFound();

        await _TicketRepository.RemoveTicketAsync(Ticket);
        await _unityOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}