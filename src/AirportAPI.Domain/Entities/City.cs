namespace Domain.Entities;

public class City
{
    public City(string name, string uf, Guid? id = null)
    {
        Name = name;
        UF = uf;
        Id = id ?? Guid.NewGuid();
    }

    private City()
    {
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string UF { get; private set; }

    public virtual IEnumerable<Airport>? Airports { get; private set; }
}