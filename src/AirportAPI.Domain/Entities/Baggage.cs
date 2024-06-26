﻿namespace Domain.Entities;

public class Baggage
{
    public Baggage(string identification, Guid ticketId, Guid? id = null)
    {
        Identification = identification;
        TicketId = ticketId;
        Id = id ?? Guid.NewGuid();
    }

    private Baggage()
    {
    }

    public Guid Id { get; private set; }
    public string Identification { get; private set; }
    public Guid TicketId { get; private set; }

    public virtual Ticket? Ticket { get; }

    public void Update(string identification)
    {
        Identification = identification;
    }
}