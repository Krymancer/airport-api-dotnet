using Airport.Domain.Common;

namespace Airport.Domain.Entities;

public class Flight : BaseEntity
{
    public string Number { get; set; } = Guid.NewGuid().ToString();
    public Guid OriginAirportId { get; set; }
    public Guid DestinationAirportId { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrival { get; set; }
    
    public virtual Airport? OriginAirport { get; set; }
    public virtual Airport? DestinationAirport { get; set; }
    public virtual IEnumerable<Ticket>? Tickets { get; set; }
    public virtual IEnumerable<FlightClass>? FlightClasses { get; set; }
}