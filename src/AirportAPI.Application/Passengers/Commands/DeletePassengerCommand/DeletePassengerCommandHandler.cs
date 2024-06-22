using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Passengers.Commands.DeletePassenger;

public class
    DeletePassengerCommandHandler : IRequestHandler<DeletePassengerCommand.DeletePassengerCommand, ErrorOr<Deleted>>
{
    private readonly IPassengerRepository _PassengerRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeletePassengerCommandHandler(IPassengerRepository PassengerRepository, IUnityOfWork unityOfWork)
    {
        _PassengerRepository = PassengerRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeletePassengerCommand.DeletePassengerCommand request,
        CancellationToken cancellationToken)
    {
        var Passenger = await _PassengerRepository.GetByIdAsync(request.PassengerId);

        if (Passenger is null) return Error.NotFound();

        await _PassengerRepository.RemovePassengerAsync(Passenger);
        await _unityOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}