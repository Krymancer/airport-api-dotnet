using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Passengers.Queries.ListPassengersQuery;

public class ListPassengersQueryHandler : IRequestHandler<ListPassengersQuery, ErrorOr<IEnumerable<Passenger>>>
{
    private readonly IPassengerRepository _PassengerRepository;

    public ListPassengersQueryHandler(IPassengerRepository PassengerRepository)
    {
        _PassengerRepository = PassengerRepository;
    }

    public async Task<ErrorOr<IEnumerable<Passenger>>> Handle(ListPassengersQuery request,
        CancellationToken cancellationToken)
    {
        var Passengers = await _PassengerRepository.ListPassengers();

        return ErrorOrFactory.From(Passengers);
    }
}