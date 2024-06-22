namespace Contracts.Managers;

public record CreateManagerRequest(
    string Name,
    string CPF,
    string Email,
    string Username,
    string Password,
    DateTime BirthDate);