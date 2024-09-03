using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace Leaderboard.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
[SwaggerControllerOrder(2)]
public class ActivityController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() 
    {
        return Ok("Hello World");
    }
}