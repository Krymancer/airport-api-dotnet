using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Cities.Queries.GetCitiesQuery;

public record GetCitiesQuery(): IRequest<ErrorOr<IEnumerable<City>>>;