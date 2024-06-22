using ErrorOr;
using MediatR;

namespace Application.Passengers.Commands.DeletePassengerCommand;

public record DeletePassengerCommand(Guid PassengerId) : IRequest<ErrorOr<Deleted>>;