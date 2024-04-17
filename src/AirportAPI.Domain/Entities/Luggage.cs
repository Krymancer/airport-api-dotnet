using Domain.Common;

namespace Domain.Entities;

public class Luggage : BaseEntity
{
    public string Identification { get; set; } = string.Empty;
    public Guid TicketId { get; set; }
    
    public virtual Ticket? Ticket { get; set; }
}