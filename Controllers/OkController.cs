using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ECOCEMProject;


[ApiController]
[Route("api/[controller]")]

public class OkController : Controller
{

    [HttpGet("admin")]
    [Authorize(Roles="admin, jefe")]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpGet("jefe")]
    [Authorize(Roles="jefe")]
    public IActionResult Get1()
    {
        return Ok();
    }

    [HttpGet("user")]
    [Authorize]
    public IActionResult Get2()
    {
        return Ok();
    }


}

