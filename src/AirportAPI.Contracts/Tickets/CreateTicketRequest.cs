namespace Contracts.Tickets;

public record CreateTicketRequest(
    string Identification,
    double Price,
    int SeatNumber,
    Guid FlightId,
    Guid PassengerId,
    bool LuggageCheckIn = false);