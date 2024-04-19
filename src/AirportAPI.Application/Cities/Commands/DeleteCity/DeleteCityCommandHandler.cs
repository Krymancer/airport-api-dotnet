using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Cities.Commands.DeleteCity;

public class DeleteCityCommandHandler: IRequestHandler<DeleteCityCommand, ErrorOr<Deleted>>
{
    private readonly ICityRepository _cityRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteCityCommandHandler(ICityRepository cityRepository, IUnityOfWork unityOfWork)
    {
        _cityRepository = cityRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.CityId);

        if (city is null) return Error.NotFound();

        await _cityRepository.RemoveCityAsync(city);
        await _unityOfWork.CommitChangesAsync();
        
        return Result.Deleted;
    }
}