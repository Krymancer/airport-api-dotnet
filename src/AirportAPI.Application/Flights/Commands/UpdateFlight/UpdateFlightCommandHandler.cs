using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Flights.Commands.UpdateFlight;

public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, ErrorOr<Updated>>
{
    private readonly IFlightRepository _flightRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateFlightCommandHandler(IFlightRepository flightRepository, IUnityOfWork unityOfWork)
    {
        _flightRepository = flightRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = await _flightRepository.GetByIdAsync(request.FlightId);

        if (flight is null) return Error.NotFound();

        await _flightRepository.UpdateFlightAsync(flight);
        await _unityOfWork.CommitChangesAsync();

        return Result.Updated;
    }
}