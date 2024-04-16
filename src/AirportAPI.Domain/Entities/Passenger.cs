using Airport.Domain.Common;

namespace Airport.Domain.Entities;

public class Passenger : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public virtual IEnumerable<Ticket>? Tickets { get; set; }
}