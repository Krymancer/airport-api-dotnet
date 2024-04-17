using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AirportController : Controller
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
}