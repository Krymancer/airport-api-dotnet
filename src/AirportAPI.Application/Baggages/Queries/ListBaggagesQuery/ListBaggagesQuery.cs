using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Baggages.Queries.ListBaggagesQuery;

public record ListBaggagesQuery : IRequest<ErrorOr<IEnumerable<Baggage>>>;