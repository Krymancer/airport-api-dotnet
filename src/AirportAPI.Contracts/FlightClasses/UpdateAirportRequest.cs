using Domain.Enums;

namespace Contracts.FlightClasses;

public record UpdateFlightClassRequest(FlightClassesEnum FlightClass, int Seats, double SeatPrice, Guid FlightId);