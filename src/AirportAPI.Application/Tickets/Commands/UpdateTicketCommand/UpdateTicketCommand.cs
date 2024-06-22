using ErrorOr;
using MediatR;

namespace Application.Tickets.Commands.UpdateTicketCommand;

public record UpdateTicketCommand(
    Guid TicketId,
    string Identification,
    double Price,
    int SeatNumber,
    Guid FlightId,
    Guid PassengerId,
    bool LuggageCheckIn = false) : IRequest<ErrorOr<Updated>>;