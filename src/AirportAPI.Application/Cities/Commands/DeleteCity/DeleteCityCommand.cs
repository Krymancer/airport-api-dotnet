using ErrorOr;
using MediatR;

namespace Application.Cities.Commands.DeleteCity;

public record DeleteCityCommand(Guid CityId): IRequest<ErrorOr<Deleted>>;