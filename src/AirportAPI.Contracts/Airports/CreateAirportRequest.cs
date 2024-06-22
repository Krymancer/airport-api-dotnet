namespace Contracts.Airports;

public record CreateAirportRequest(string IATACode, string Name, Guid CityId);