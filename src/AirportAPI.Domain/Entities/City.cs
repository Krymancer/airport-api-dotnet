using Domain.Common;

namespace Domain.Entities;

public class City: BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string UF { get; set; } = String.Empty;
    
    public virtual IEnumerable<Airport>? Airports { get; set; }

}