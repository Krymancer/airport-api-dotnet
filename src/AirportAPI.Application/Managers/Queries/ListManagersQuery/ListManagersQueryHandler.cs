using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Managers.Queries.ListManagersQuery;

public class ListManagersQueryHandler : IRequestHandler<ListManagersQuery, ErrorOr<IEnumerable<Manager>>>
{
    private readonly IManagerRepository _managerRepository;

    public ListManagersQueryHandler(IManagerRepository managerRepository)
    {
        _managerRepository = managerRepository;
    }

    public async Task<ErrorOr<IEnumerable<Manager>>> Handle(ListManagersQuery request,
        CancellationToken cancellationToken)
    {
        var managers = await _managerRepository.ListManagers();

        return ErrorOrFactory.From(managers);
    }
}