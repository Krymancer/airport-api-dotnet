namespace Airport.Domain.Entities;

public class City
{
    public string Name { get; set; } = String.Empty;
    public string UF { get; set; } = String.Empty;
    
    public virtual IEnumerable<Airport>? Airports { get; set; }

}