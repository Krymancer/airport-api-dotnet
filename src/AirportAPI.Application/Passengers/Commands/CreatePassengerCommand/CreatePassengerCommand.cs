using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Passengers.Commands.CreatePassengerCommand;

public record CreatePassengerCommand(string Name, string CPF, string Email, DateTime BirthDate)
    : IRequest<ErrorOr<Passenger>>;