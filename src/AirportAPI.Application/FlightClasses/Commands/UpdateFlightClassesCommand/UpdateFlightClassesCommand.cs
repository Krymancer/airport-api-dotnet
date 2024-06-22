using Domain.Enums;
using ErrorOr;
using MediatR;

namespace Application.FlightClasses.Commands.UpdateFlightClassesCommand;

public record UpdateFlightClassCommand(
    Guid FlightClassId,
    FlightClassesEnum FlightClass,
    int Seats,
    double SeatPrice,
    Guid FlightId) : IRequest<ErrorOr<Updated>>;