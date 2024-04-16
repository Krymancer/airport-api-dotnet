using Airport.Domain.Common;

namespace Airport.Domain.Entities;

public class Airport : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string IATACode { get; set; } = string.Empty;
    public Guid CityId { get; set; }
    
    public virtual City? City { get; set; }
}