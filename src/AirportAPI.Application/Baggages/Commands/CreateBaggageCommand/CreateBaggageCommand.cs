using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Baggages.Commands.CreateBaggageCommand;

public record CreateBaggageCommand(string Identification, Guid TicketId) : IRequest<ErrorOr<Baggage>>;