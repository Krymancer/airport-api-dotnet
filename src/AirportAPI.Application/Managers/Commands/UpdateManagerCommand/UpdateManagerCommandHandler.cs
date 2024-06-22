using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Managers.Commands.UpdateManagerCommand;

public class UpdateManagerCommandHandler : IRequestHandler<UpdateManagerCommand, ErrorOr<Updated>>
{
    private readonly IManagerRepository _managerRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateManagerCommandHandler(IManagerRepository managerRepository, IUnityOfWork unityOfWork)
    {
        _managerRepository = managerRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
    {
        var manager = await _managerRepository.GetByIdAsync(request.ManagerId);

        if (manager is null) return Error.NotFound();

        manager.Update(request.Name, request.CPF, request.Email, request.Username, request.Password,
            request.BirthDate);

        await _managerRepository.UpdateManagerAsync(manager);
        await _unityOfWork.CommitChangesAsync();

        return Result.Updated;
    }
}