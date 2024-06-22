using Application.Common.Interfaces;
using Domain.Validators;
using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Commands.UpdateFlightClassesCommand;

public class UpdateFlightClassCommandHandler : IRequestHandler<UpdateFlightClassCommand, ErrorOr<Updated>>
{
    private readonly IFlightClassRepository _flightClassRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateFlightClassCommandHandler(IFlightClassRepository flightClassRepository, IUnityOfWork unityOfWork)
    {
        _flightClassRepository = flightClassRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateFlightClassCommand request, CancellationToken cancellationToken)
    {
        var flightClass = await _flightClassRepository.GetByIdAsync(request.FlightClassId);

        if (flightClass is null) return Error.NotFound();

        flightClass.Update(request.FlightClass, request.Seats, request.SeatPrice);

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

        await _flightClassRepository.UpdateFlightClassAsync(flightClass);
        await _unityOfWork.CommitChangesAsync();

        return Result.Updated;
    }
}