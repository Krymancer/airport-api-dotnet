using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Flights.Commands.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, ErrorOr<Flight>>
{
    private readonly IFlightRepository _flightRepository;
    private readonly IUnityOfWork _unityOfWork;

    public CreateFlightCommandHandler(IFlightRepository flightRepository, IUnityOfWork unityOfWork)
    {
        _flightRepository = flightRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<ErrorOr<Flight>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = new Flight(
            request.FlightNumber,
            request.Departure,
            request.Arrival,
            request.OriginAirport,
            request.DestinationAirport
        );
        await _flightRepository.AddFlightAsync(flight);
        await _unityOfWork.CommitChangesAsync();
        return flight;
    }
}