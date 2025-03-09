using DotDesk.Api.DTO.AttenderRegister;
using DotDesk.Application.Services.Abstraction;
using DotDesk.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DotDesk.Api.Controllers
{
    public class AttenderController : DotDeskControllerBase
    {
        private IAttenderService _attenderService;

        public AttenderController(IAttenderService attenderService)
        {
            _attenderService = attenderService;
        }

        [HttpPost]
        public async Task<ActionResult<AttenderRegistrationDTO>> Create(AttenderRegistrationDTO attenderRegistrationDTO)
        {
            Attender createdAttender = await _attenderService.Create(attenderRegistrationDTO.ExtractAttender());
            AttenderRegistrationDTO response = AttenderRegistrationDTO.CreateDtoFrom(createdAttender);
            return CreatedAtAction(nameof(Create), response);
        }
    }
}

