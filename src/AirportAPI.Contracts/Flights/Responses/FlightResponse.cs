namespace Contracts.Flights.Responses;

public record FlightResponse(string FlightNumber, DateTime Departure, DateTime Arrival);