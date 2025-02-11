using DotDesk.Domain.Entities;

namespace DotDesk.Application.Services.Abstraction;

public interface IDotDeskClientService
{
    Task<DotDeskClient> Register(DotDeskClient newDotDeskClient);
}