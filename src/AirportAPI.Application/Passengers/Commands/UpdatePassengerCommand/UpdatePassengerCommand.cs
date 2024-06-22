using ErrorOr;
using MediatR;

namespace Application.Passengers.Commands.UpdatePassengerCommand;

public record UpdatePassengerCommand(Guid PassengerId, string Name, string CPF, string Email, DateTime BirthDate) : IRequest<ErrorOr<Updated>>;