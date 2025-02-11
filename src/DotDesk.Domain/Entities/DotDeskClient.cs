using DotDesk.Domain.Entities.Abstractions;

namespace DotDesk.Domain.Entities;

public class DotDeskClient : Entity
{
    public string Name { get; private set; }
    public string Identity { get; private set; }
    public DotDeskClientResponsible Responsible { get; set; }
    public List<Attender> Attenders { get; private set; }

    public DotDeskClient(string name, string identity, DotDeskClientResponsible responsible)
    {
        Name = name;
        Identity = identity;
        Attenders = new();
        Responsible = responsible;
    }
}