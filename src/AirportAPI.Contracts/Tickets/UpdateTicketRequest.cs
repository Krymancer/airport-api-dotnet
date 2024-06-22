namespace Contracts.Tickets;

public record UpdateTicketRequest(
    string Identification,
    double Price,
    int SeatNumber,
    Guid FlightId,
    Guid PassengerId,
    bool LuggageCheckIn = false);