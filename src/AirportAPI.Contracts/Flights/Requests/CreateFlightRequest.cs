namespace Contracts.Flights.Requests;

public record CreateFlightRequest(
    string FlightNumber,
    Guid OriginAirportId,
    Guid DestinationAirportId,
    DateTime Departure,
    DateTime Arrival);