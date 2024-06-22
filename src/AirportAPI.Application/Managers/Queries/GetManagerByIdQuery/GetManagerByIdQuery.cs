using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Managers.Queries.GetManagerByIdQuery;

public record GetManagerByIdQuery(Guid ManagerId) : IRequest<ErrorOr<Manager>>;