using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Cities.Queries.GetCitiesQuery;

public class GetCitiesQueryHandler: IRequestHandler<GetCitiesQuery, ErrorOr<IEnumerable<City>>>
{
    private readonly ICityRepository _cityRepository;

    public GetCitiesQueryHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ErrorOr<IEnumerable<City>>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        var cities = await _cityRepository.GetAll();

        return cities.ToErrorOr();
    }
}