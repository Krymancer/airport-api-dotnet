using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Passengers.Commands.UpdatePassengerCommand;

public class UpdatePassengerCommandHandler : IRequestHandler<UpdatePassengerCommand, ErrorOr<Updated>>
{
    private readonly IPassengerRepository _passengerRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdatePassengerCommandHandler(IPassengerRepository PassengerRepository, IUnityOfWork unityOfWork)
    {
        _passengerRepository = PassengerRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdatePassengerCommand request, CancellationToken cancellationToken)
    {
        var passenger = await _passengerRepository.GetByIdAsync(request.PassengerId);

        if (passenger is null) return Error.NotFound();

        passenger.Update(request.Name, request.CPF, request.Email, request.BirthDate);

        await _passengerRepository.UpdatePassengerAsync(passenger);
        await _unityOfWork.CommitChangesAsync();

        return Result.Updated;
    }
}