using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ECOCEMProject;


[ApiController]
[Route("api/[controller]")]

public class OkController : Controller
{

    [HttpGet("admin")]
    [Authorize(Roles="admin")]
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


}

