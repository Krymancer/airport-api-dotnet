using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Validators;
using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Commands.CreateFlightClassesCommand;

public class CreateFlightClassCommandHandler : IRequestHandler<CreateFlightClassCommand, ErrorOr<FlightClass>>
{
    private readonly IFlightClassesRepository _flightClassRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CreateFlightClassCommandHandler(IFlightClassesRepository flightClassRepository, IUnityOfWork unityOfWork)
    {
        _flightClassRepository = flightClassRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<FlightClass>> Handle(CreateFlightClassCommand request,
        CancellationToken cancellationToken)
    {
        var flightClass = new FlightClass(request.FlightClass, request.Seats, request.SeatPrice, request.FlightId);
        var validator = new FlightClassValidator();

        var validationResult = await validator.ValidateAsync(flightClass, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .ConvertAll(error => Error.Validation(
                    error.PropertyName,
                    error.ErrorMessage));

            return errors;
        }

        await _flightClassRepository.AddFlightClassAsync(flightClass);
        await _unityOfWork.CommitChangesAsync();

        return flightClass;
    }
}