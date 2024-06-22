using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Airports.Commands.UpdateAirportCommand;

public class UpdateAirportCommandHandler : IRequestHandler<global::UpdateAirportCommand, ErrorOr<Updated>>
{
    private readonly IAirportRepository _airportRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateAirportCommandHandler(IAirportRepository airportRepository, IUnityOfWork unityOfWork)
    {
        _airportRepository = airportRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(global::UpdateAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = await _airportRepository.GetByIdAsync(request.AirportId);

        if (airport is null) return Error.NotFound();

        airport.Update(request.Name, request.IATACode);

        await _airportRepository.UpdateAirportAsync(airport);
        await _unityOfWork.CommitChangesAsync();

        return Result.Updated;
    }
}