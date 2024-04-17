namespace Domain.Entities;

public class Luggage
{
    public Guid Id { get; private set; }
    public string Identification { get; private set; }
    public Guid TicketId { get; private set; }

    public virtual Ticket? Ticket { get; private set; }

    public Luggage(string identification, Guid ticketId, Guid? id)
    {
        Identification = identification;
        TicketId = ticketId;
        Id = id ?? Guid.NewGuid();
    }

    private Luggage()
    {
    }
}