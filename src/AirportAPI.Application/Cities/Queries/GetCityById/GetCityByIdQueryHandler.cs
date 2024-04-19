using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Cities.Queries.GetCityById;

public class GetCityByIdQueryHandler: IRequestHandler<GetCityByIdQuery, ErrorOr<City>>
{
    private readonly ICityRepository _cityRepository;

    public GetCityByIdQueryHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ErrorOr<City>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var city = await _cityRepository.GetByIdAsync(request.CityId);

        if (city is null) return Error.NotFound();

        return city;
    }
}