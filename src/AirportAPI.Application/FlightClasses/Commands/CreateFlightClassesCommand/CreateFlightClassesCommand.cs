using Domain.Entities;
using Domain.Enums;
using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Commands.CreateFlightClassesCommand;

public record CreateFlightClassCommand(
    FlightClassesEnum FlightClass,
    int Seats,
    double SeatPrice,
    Guid FlightId) : IRequest<ErrorOr<FlightClass>>;