using Domain.Common;

namespace Domain.Entities;

public class Ticket : BaseEntity
{
    public Guid PassengerId { get; set; }
    public Guid FlightId { get; set; }
    public string Identification { get; set; } = string.Empty;
    public double TotalPrice { get; set; }
    public bool LuggageCheckIn { get; set; }
    public int SeatNumber { get; set; }

    public virtual Passenger? Passenger { get; set; }
    public virtual Flight? Flight { get; set; }
    public virtual Luggage? Luggage { get; set; }
}