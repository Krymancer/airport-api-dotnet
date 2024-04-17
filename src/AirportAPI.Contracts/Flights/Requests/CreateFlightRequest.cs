namespace Contracts.Flights.Requests;

public record CreateFlightRequest(string OriginIATACode, string DestinationIATACode, DateTime Departure, DateTime Arrival);