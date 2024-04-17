using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class FlightClass: BaseEntity
{
    public FlightClassesEnum Class { get; set; }
    public int Seats { get; set; }
    public double SeatPrice { get; set; }
    public Guid FlightId { get; set; }
    
    public virtual Flight? Flight { get; set; }
}