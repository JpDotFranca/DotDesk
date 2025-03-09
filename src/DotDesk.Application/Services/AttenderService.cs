using DotDesk.Application.Services.Abstraction;
using DotDesk.Domain.Entities;

namespace DotDesk.Application.Services
{
    public class AttenderService : IAttenderService
    {
        private IAttenderRepository _attenderRepository;
        public AttenderService(IAttenderRepository attenderRepository)
        {
            _attenderRepository = attenderRepository;
        }

        public async Task<Attender> Create(Attender newAttender)
        {
            return await _attenderRepository.Create(newAttender);
        }

        public async Task<Attender> Get(string id)
            => await _attenderRepository.Get(id);

        public async Task<Attender> Get(Attender filter)
            => await _attenderRepository.Get(filter);
    }
}
