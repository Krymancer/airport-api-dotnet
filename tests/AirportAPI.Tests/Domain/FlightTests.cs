using Domain.Entities;

namespace Tests.Domain;

public class FlightTests
{
    [Fact]
    public void Flight_Should_Have_a_Unique_Identification_Number()
    {
        var flight = new Flight();
        var anotherFlight = new Flight();

        flight.Number.Should().NotBeEquivalentTo(anotherFlight.Number);
    }

    // API test maybe
    [Fact]
    public void Flight_Should_Have_Different_Origin_and_Destination_Airports()
    {
        var airport = new Airport();
        
        var flight = new Flight
        {
            OriginAirportId = airport.Id,
            DestinationAirportId = airport.Id,
            OriginAirport = airport,
            DestinationAirport = airport
        };
    }
}