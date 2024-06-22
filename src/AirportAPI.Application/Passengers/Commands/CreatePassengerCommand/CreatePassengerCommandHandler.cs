using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Validators;
using ErrorOr;
using MediatR;

namespace Application.Passengers.Commands.CreatePassengerCommand;

public class CreatePassengerCommandHandler : IRequestHandler<CreatePassengerCommand, ErrorOr<Passenger>>
{
    private readonly IPassengerRepository _passengerRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CreatePassengerCommandHandler(IPassengerRepository passengerRepository, IUnityOfWork unityOfWork)
    {
        _passengerRepository = passengerRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Passenger>> Handle(CreatePassengerCommand request, CancellationToken cancellationToken)
    {
        var passenger = new Passenger(request.Name, request.CPF, request.Email, request.BirthDate);
        var validator = new PassengerValidator();

        var validationResult = await validator.ValidateAsync(passenger, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .ConvertAll(error => Error.Validation(
                    error.PropertyName,
                    error.ErrorMessage));

            return errors;
        }

        await _passengerRepository.AddPassengerAsync(passenger);
        await _unityOfWork.CommitChangesAsync();

        return passenger;
    }
}