using Application.Common.Interfaces;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Baggages.Queries.ListBaggagesQuery;

public class ListBaggagesQueryHandler : IRequestHandler<ListBaggagesQuery, ErrorOr<IEnumerable<Baggage>>>
{
    private readonly IBaggageRepository _baggageRepository;

    public ListBaggagesQueryHandler(IBaggageRepository baggageRepository)
    {
        _baggageRepository = baggageRepository;
    }

    public async Task<ErrorOr<IEnumerable<Baggage>>> Handle(ListBaggagesQuery request,
        CancellationToken cancellationToken)
    {
        var baggages = await _baggageRepository.ListBaggages();
        return ErrorOrFactory.From(baggages);
    }
}