namespace Domain.Entities;

public class Flight
{
    public Flight(string number, DateTime departure, DateTime arrival, Guid originAirportId, Guid destinationAirportId,
        Guid? id = null)
    {
        Number = number;
        Departure = departure;
        Arrival = arrival;
        OriginAirportId = originAirportId;
        DestinationAirportId = destinationAirportId;
        Id = id ?? Guid.NewGuid();
    }

    private Flight()
    {
    }

    public Guid Id { get; private set; }
    public string Number { get; private set; }
    public Guid OriginAirportId { get; private set; }
    public Guid DestinationAirportId { get; private set; }
    public DateTime Departure { get; private set; }
    public DateTime Arrival { get; private set; }

    public virtual Airport? OriginAirport { get; }
    public virtual Airport? DestinationAirport { get; }
    public virtual IEnumerable<Ticket>? Tickets { get; }
    public virtual IEnumerable<FlightClass>? FlightClasses { get; }
}