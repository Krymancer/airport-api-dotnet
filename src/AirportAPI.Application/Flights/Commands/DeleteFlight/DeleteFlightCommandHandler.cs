using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Flights.Commands.DeleteFlight;

public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, ErrorOr<Deleted>>
{
    private readonly IFlightRepository _flightRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DeleteFlightCommandHandler(IFlightRepository flightRepository, IUnityOfWork unityOfWork)
    {
        _flightRepository = flightRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = await _flightRepository.GetByIdAsync(request.FlightId);

        if (flight is null) return Error.NotFound();

        await _flightRepository.RemoveFlightAsync(flight);
        await _unityOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}