namespace Domain.Entities;

public class Ticket
{
    public Ticket(string identification, double price, int seatNumber, Guid flightId, Guid passengerId,
        bool luggageCheckIn = false, Guid? id = null)
    {
        Identification = identification;
        TotalPrice = price;
        SeatNumber = seatNumber;
        FlightId = flightId;
        PassengerId = passengerId;
        LuggageCheckIn = luggageCheckIn;
        Id = id ?? Guid.NewGuid();
    }

    private Ticket()
    {
    }

    public Guid Id { get; private set; }
    public Guid PassengerId { get; private set; }
    public Guid FlightId { get; private set; }
    public string Identification { get; private set; }
    public double TotalPrice { get; private set; }
    public bool LuggageCheckIn { get; private set; }
    public int SeatNumber { get; private set; }

    public virtual Passenger? Passenger { get; }
    public virtual Flight? Flight { get; }
    public virtual Baggage? Luggage { get; }
}