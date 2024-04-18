using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Cities.Commands.CreateCity;

public record CreateCityCommand(string Name, string UF): IRequest<ErrorOr<City>>;