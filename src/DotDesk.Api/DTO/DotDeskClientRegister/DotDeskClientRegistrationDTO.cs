using DotDesk.Domain.Entities;

namespace DotDesk.Api.DTO.DotDeskClientRegister;

public class DotDeskClientRegistrationDTO
{
    public string Name { get; set; }
    public string Identity { get; set; }
    public DotDeskClientResponsibleDTO DotDeskClientResponsible { get; set; }

    public DotDeskClient Map()
    {
        return new DotDeskClient(this.Name, this.Identity, this.DotDeskClientResponsible.Map());
    }
    
}