using DotDesk.Domain.Entities.Abstractions;

namespace DotDesk.Domain.Entities;

public class Attender: Entity
{
    public string Name { get;  private set; }
    public string Email { get; private set; }

    public Attender(string name, string email)
    {
        Name = name;
        Email = email;
    }
}