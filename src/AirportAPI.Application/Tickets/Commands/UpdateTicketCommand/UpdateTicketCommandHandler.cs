using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Tickets.Commands.UpdateTicketCommand;

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, ErrorOr<Updated>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateTicketCommandHandler(ITicketRepository ticketRepository, IUnityOfWork unityOfWork)
    {
        _ticketRepository = ticketRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetByIdAsync(request.TicketId);

        if (ticket is null) return Error.NotFound();

        ticket.Update(request.Identification, request.Price, request.SeatNumber, request.FlightId, request.PassengerId, request.LuggageCheckIn);

        await _ticketRepository.UpdateTicketAsync(ticket);
        await _unityOfWork.CommitChangesAsync();

        return Result.Updated;
    }
}