using Microsoft.AspNetCore.Mvc;
namespace HomeManagment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("API funcionando correctamente 🟢");
}
