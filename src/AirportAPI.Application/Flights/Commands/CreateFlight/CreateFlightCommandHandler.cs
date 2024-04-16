using ErrorOr;
using MediatR;

namespace Application.Flights.Commands.CreateFlight;

public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, ErrorOr<string>>
{
    public async Task<ErrorOr<string>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        return Error.Unexpected("IATA", "Wow an error");
    }
}