using DotDesk.Domain.Entities.Abstractions;

namespace DotDesk.Domain.Entities;

public class DotDeskClientResponsible: Entity
{
    public string Name { get; private set; }
    public string Identity { get; private set; }

    public DotDeskClientResponsible(string name, string identity)
    {
        Name = name;
        Identity = identity;
    }
}