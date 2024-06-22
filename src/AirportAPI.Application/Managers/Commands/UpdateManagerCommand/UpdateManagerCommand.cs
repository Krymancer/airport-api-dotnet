using ErrorOr;
using MediatR;

namespace Application.Managers.Commands.UpdateManagerCommand;

public record UpdateManagerCommand(
    Guid ManagerId,
    string Name,
    string CPF,
    string Email,
    string Username,
    string Password,
    DateTime BirthDate) : IRequest<ErrorOr<Updated>>;