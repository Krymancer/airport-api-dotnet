using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Managers.Commands.DeleteManagerCommand;

public class DeleteManagerCommandHandler : IRequestHandler<DeleteManagerCommand, ErrorOr<Deleted>>
{
    private readonly IManagerRepository _managerRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteManagerCommandHandler(IManagerRepository managerRepository, IUnityOfWork unityOfWork)
    {
        _managerRepository = managerRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteManagerCommand request,
        CancellationToken cancellationToken)
    {
        var manager = await _managerRepository.GetByIdAsync(request.ManagerId);

        if (manager is null) return Error.NotFound();

        await _managerRepository.RemoveManagerAsync(manager);
        await _unityOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}