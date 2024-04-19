using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Cities.Queries.ListCities;

public record ListCitiesQuery : IRequest<ErrorOr<IEnumerable<City>>>;