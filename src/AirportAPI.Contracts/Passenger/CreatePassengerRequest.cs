namespace Contracts.Passenger;

public record CreatePassengerRequest(string Name, string CPF, string Email, DateTime BirthDate);