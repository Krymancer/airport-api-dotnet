namespace Contracts.Managers;

public record UpdateManagerRequest(
    string Name,
    string CPF,
    string Email,
    string Username,
    string Password,
    DateTime BirthDate);