using DotDesk.Domain.Entities;

public interface IAttenderRepository
{
    Task<Attender> Create(Attender newAttender);
    Task<Attender> Get(Attender attenderFilter);
    Task<Attender> Get(string id);
}