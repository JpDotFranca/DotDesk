using DotDesk.Application.Services.Abstraction;
using DotDesk.Domain.Entities;
using DotDesk.UserPanelBFF.DTO.DotDeskClientRegister;
using Microsoft.AspNetCore.Mvc;

namespace DotDesk.UserPanelBFF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DotDeskClientController : ControllerBase
{
    private IDotDeskClientService _dotDeskClientService { get; init; }

    public DotDeskClientController(IDotDeskClientService dotDeskClientService)
    {
        _dotDeskClientService = dotDeskClientService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterDotDeskClient(DotDeskClientRegistrationDTO dotDeskClientRegister)
    {
        DotDeskClient registeredClient = await _dotDeskClientService.Register(dotDeskClientRegister.Map());
        return Ok(registeredClient);
    }
}