using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Airports.Commands.DeleteAirport;

public class DeleteAirportCommandHandler : IRequestHandler<DeleteAirportCommand.DeleteAirportCommand, ErrorOr<Deleted>>
{
    private readonly IAirportRepository _airportRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteAirportCommandHandler(IAirportRepository airportRepository, IUnityOfWork unityOfWork)
    {
        _airportRepository = airportRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteAirportCommand.DeleteAirportCommand request,
        CancellationToken cancellationToken)
    {
        var airport = await _airportRepository.GetByIdAsync(request.AirportId);

        if (airport is null) return Error.NotFound();

        await _airportRepository.RemoveAirportAsync(airport);
        await _unityOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}