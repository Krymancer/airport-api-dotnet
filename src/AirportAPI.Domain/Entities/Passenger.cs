namespace Domain.Entities;

public class Passenger
{
    public Passenger(string name, string cpf, string email, DateTime birthDate, Guid? id = null)
    {
        Name = name;
        CPF = cpf;
        Email = email;
        BirthDate = birthDate;
        Id = id ?? Guid.NewGuid();
    }

    private Passenger()
    {
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string CPF { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }

    public virtual IEnumerable<Ticket>? Tickets { get; }
}