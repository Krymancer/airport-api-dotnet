using Application.Cities.Commands.DeleteCity;
using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Cities.Commands.UpdateCity;

public class UpdateCityCommandHandler: IRequestHandler<UpdateCityCommand, ErrorOr<Updated>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateCityCommandHandler(ICityRepository cityRepository, IUnityOfWork unityOfWork)
    {
        _cityRepository = cityRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.CityId);

        if (city is null) return Error.NotFound();

        await _cityRepository.UpdateCityAsync(city);
        await _unityOfWork.CommitChangesAsync();
        
        return Result.Updated;
    }
}