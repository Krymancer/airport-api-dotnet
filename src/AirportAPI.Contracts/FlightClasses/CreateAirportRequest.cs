using Domain.Enums;

namespace Contracts.FlightClasses;

public record CreateFlightClassRequest(FlightClassesEnum FlightClass, int Seats, double SeatPrice, Guid FlightId);