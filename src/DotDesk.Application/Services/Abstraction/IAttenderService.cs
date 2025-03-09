using DotDesk.Domain.Entities;

namespace DotDesk.Application.Services.Abstraction
{
    public interface IAttenderService
    {
        Task<Attender> Create(Attender newAttender);
        Task<Attender> Get(Attender filter);
        Task<Attender> Get(string id);
    }
}