using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Managers.Commands.CreateManagerCommand;

public record CreateManagerCommand(
    string Name,
    string CPF,
    string Email,
    string Username,
    string Password,
    DateTime BirthDate) : IRequest<ErrorOr<Manager>>;