namespace Contracts.Passenger;

public record UpdatePassengerRequest(string Name, string CPF, string Email, DateTime BirthDate);