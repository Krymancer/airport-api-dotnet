using ErrorOr;
using MediatR;

namespace Application.Cities.Commands.UpdateCity;

public record UpdateCityCommand(Guid CityId) : IRequest<ErrorOr<Updated>>;