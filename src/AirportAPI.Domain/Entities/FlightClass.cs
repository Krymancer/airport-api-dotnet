using Domain.Enums;

namespace Domain.Entities;

public class FlightClass
{
    public FlightClass(FlightClassesEnum flightClass, int seats, double seatPrice, Guid flightId, Guid? id)
    {
        Class = flightClass;
        Seats = seats;
        FlightId = flightId;
        Id = id ?? Guid.NewGuid();
    }

    private FlightClass()
    {
    }

    public Guid Id { get; private set; }
    public FlightClassesEnum Class { get; private set; }
    public int Seats { get; private set; }
    public double SeatPrice { get; }
    public Guid FlightId { get; private set; }

    public virtual Flight? Flight { get; }
}