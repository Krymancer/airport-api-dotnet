using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Tickets.Commands.CreateTicketCommand;

public record CreateTicketCommand(
    string Identification,
    double Price,
    int SeatNumber,
    Guid FlightId,
    Guid PassengerId,
    bool LuggageCheckIn = false) : IRequest<ErrorOr<Ticket>>;