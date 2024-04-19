using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Cities.Queries.ListCities;

public class ListCitiesQueryHandler: IRequestHandler<ListCitiesQuery, ErrorOr<IEnumerable<City>>>
{
    private readonly ICityRepository _cityRepository;

    public ListCitiesQueryHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ErrorOr<IEnumerable<City>>> Handle(ListCitiesQuery request, CancellationToken cancellationToken)
    {
        var cities = await _cityRepository.ListCities();

        return ErrorOrFactory.From(cities);
    }
}