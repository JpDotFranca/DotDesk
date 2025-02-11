using DotDesk.Domain.Entities;

namespace DotDesk.Application.Services.Abstraction;

public class DotDeskClientService:IDotDeskClientService
{
    
    public DotDeskClientService()
    {
        
    }
    
    public async Task<DotDeskClient> Register(DotDeskClient newDotDeskClient)
    {
        throw new NotImplementedException();
    }
}