using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Managers.Queries.ListManagersQuery;

public record ListManagersQuery : IRequest<ErrorOr<IEnumerable<Manager>>>;