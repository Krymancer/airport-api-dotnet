using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Managers.Queries.GetManagerById;

public class GetManagerByIdQueryHandler : IRequestHandler<GetManagerByIdQuery.GetManagerByIdQuery, ErrorOr<Manager>>
{
    private readonly IManagerRepository _managerRepository;

    public GetManagerByIdQueryHandler(IManagerRepository ManagerRepository)
    {
        _managerRepository = ManagerRepository;
    }

    public async Task<ErrorOr<Manager>> Handle(GetManagerByIdQuery.GetManagerByIdQuery request,
        CancellationToken cancellationToken)
    {
        var manager = await _managerRepository.GetByIdAsync(request.ManagerId);

        if (manager is null) return Error.NotFound();

        return manager;
    }
}