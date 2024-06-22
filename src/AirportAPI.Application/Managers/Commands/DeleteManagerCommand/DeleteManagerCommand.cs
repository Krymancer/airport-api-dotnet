using ErrorOr;
using MediatR;

namespace Application.Managers.Commands.DeleteManagerCommand;

public record DeleteManagerCommand(Guid ManagerId) : IRequest<ErrorOr<Deleted>>;