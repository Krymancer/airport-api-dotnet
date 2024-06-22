using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Validators;
using ErrorOr;
using MediatR;

namespace Application.Managers.Commands.CreateManagerCommand;

public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, ErrorOr<Manager>>
{
    private readonly IManagerRepository _managerRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CreateManagerCommandHandler(IManagerRepository managerRepository, IUnityOfWork unityOfWork)
    {
        _managerRepository = managerRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Manager>> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
    {
        var manager = new Manager(request.Name, request.CPF, request.Email, request.Username, request.Password,
            request.BirthDate);
        var validator = new ManagerValidator();

        var validationResult = await validator.ValidateAsync(manager, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .ConvertAll(error => Error.Validation(
                    error.PropertyName,
                    error.ErrorMessage));

            return errors;
        }

        await _managerRepository.AddManagerAsync(manager);
        await _unityOfWork.CommitChangesAsync();

        return manager;
    }
}