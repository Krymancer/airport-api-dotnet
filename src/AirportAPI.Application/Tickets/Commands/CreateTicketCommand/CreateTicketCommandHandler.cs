using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Validators;
using ErrorOr;
using MediatR;

namespace Application.Tickets.Commands.CreateTicketCommand;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ErrorOr<Ticket>>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository, IUnityOfWork unityOfWork)
    {
        _ticketRepository = ticketRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Ticket>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket(request.Identification, request.Price, request.SeatNumber, request.FlightId, request.PassengerId, request.LuggageCheckIn);
        var validator = new TicketValidator();

        var validationResult = await validator.ValidateAsync(ticket, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .ConvertAll(error => Error.Validation(
                    error.PropertyName,
                    error.ErrorMessage));

            return errors;
        }

        await _ticketRepository.AddTicketAsync(ticket);
        await _unityOfWork.CommitChangesAsync();

        return ticket;
    }
}