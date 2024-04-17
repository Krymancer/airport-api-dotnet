namespace Domain.Entities;

public class Manager
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string CPF { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public DateTime BirthDate { get; private set; }

    public Manager(
        string name, string cpf, string email, string username, string password, DateTime birthDate, Guid? id
    )
    {
        Name = name;
        CPF = cpf;
        Email = email;
        Username = username;
        Password = password;
        BirthDate = birthDate;
        Id = id ?? Guid.NewGuid();
    }

    private Manager()
    {
    }
}