using Microsoft.AspNetCore.Mvc;

namespace DotDesk.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class DotDeskControllerBase: ControllerBase
    {
    }
}
