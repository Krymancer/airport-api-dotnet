namespace Airport.Contracts.Flights.Requests;

public record CreateFlightRequest(string OriginIATACode, string DestiantionIATACode, DateTime Departure, DateTime Arrival);