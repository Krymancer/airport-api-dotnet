using Airport.Domain.Common;
using Airport.Domain.Enums;

namespace Airport.Domain.Entities;

public class FlightClass: BaseEntity
{
    public FlightClassesEnum Class { get; set; }
    public int Seats { get; set; }
    public double SeatPrice { get; set; }
    public Guid FlightId { get; set; }
    
    public virtual Flight? Flight { get; set; }
}