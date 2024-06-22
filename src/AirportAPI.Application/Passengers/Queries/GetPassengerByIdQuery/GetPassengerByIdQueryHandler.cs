using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Passengers.Queries.GetPassengerById;

public class
    GetPassengerByIdQueryHandler : IRequestHandler<GetPassengerByIdQuery.GetPassengerByIdQuery, ErrorOr<Passenger>>
{
    private readonly IPassengerRepository _PassengerRepository;

    public GetPassengerByIdQueryHandler(IPassengerRepository PassengerRepository)
    {
        _PassengerRepository = PassengerRepository;
    }

    public async Task<ErrorOr<Passenger>> Handle(GetPassengerByIdQuery.GetPassengerByIdQuery request,
        CancellationToken cancellationToken)
    {
        var Passenger = await _PassengerRepository.GetByIdAsync(request.PassengerId);

        if (Passenger is null) return Error.NotFound();

        return Passenger;
    }
}