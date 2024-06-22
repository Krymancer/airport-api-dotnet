using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Flights.Queries.ListFlights;

public record ListFlightsQuery : IRequest<ErrorOr<IEnumerable<Flight>>>;