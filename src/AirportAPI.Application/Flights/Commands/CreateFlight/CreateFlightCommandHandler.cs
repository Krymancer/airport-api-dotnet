using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Flights.Commands.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, ErrorOr<Flight>>
{
    private readonly IFlightRepository _flightRepository;

    public CreateFlightCommandHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<ErrorOr<Flight>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = new Flight();
        await _flightRepository.AddFlightAsync(flight);

        return flight;
    }
}