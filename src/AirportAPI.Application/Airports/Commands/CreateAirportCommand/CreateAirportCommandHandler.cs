using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Validators;
using ErrorOr;
using MediatR;

namespace Application.Airports.Commands.CreateAirportCommand;

public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, ErrorOr<Airport>>
{
    private readonly IAirportRepository _airportRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CreateAirportCommandHandler(IAirportRepository airportRepository, IUnityOfWork unityOfWork)
    {
        _airportRepository = airportRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Airport>> Handle(Commands.CreateAirportCommand.CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = new Airport(request.IATACode, request.Name, request.CityId);
        var validator = new AirportValidator();

        var validationResult = await validator.ValidateAsync(airport, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .ConvertAll(error => Error.Validation(
                    error.PropertyName,
                    error.ErrorMessage));

            return errors;
        }

        await _airportRepository.AddAirportAsync(airport);
        await _unityOfWork.CommitChangesAsync();

        return airport;
    }
}