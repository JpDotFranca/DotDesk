using Microsoft.AspNetCore.Mvc;

namespace DotDesk.UserPanelBFF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        public async Task<IActionResult> Get(int conversationId)
        {
            return await Task.FromResult(Ok());
        }
    }
}
