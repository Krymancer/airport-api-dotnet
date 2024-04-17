namespace Contracts.Flights.Requests;

public record CreateFlightRequest(
    string FlightNumber,
    Guid OriginAirportId,
    Guid DestinationAiportId,
    DateTime Departure,
    DateTime Arrival);