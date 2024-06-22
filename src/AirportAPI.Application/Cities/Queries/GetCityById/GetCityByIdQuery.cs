using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Cities.Queries.GetCityById;

public record GetCityByIdQuery(Guid CityId) : IRequest<ErrorOr<City>>;