using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Validators;
using ErrorOr;
using MediatR;

namespace Application.Cities.Commands.CreateCity;

public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, ErrorOr<City>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CreateCityCommandHandler(ICityRepository cityRepository, IUnityOfWork unityOfWork)
    {
        _cityRepository = cityRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<City>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        var city = new City(request.Name, request.UF);
        var validator = new CityValidator();

        var validationResult = await validator.ValidateAsync(city, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .ConvertAll(error => Error.Validation(
                    error.PropertyName,
                    error.ErrorMessage));

            return errors;
        }

        await _cityRepository.AddCityAsync(city);
        await _unityOfWork.CommitChangesAsync();

        return city;
    }
}