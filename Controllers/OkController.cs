using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ECOCEMProject;


[ApiController]
[Route("api/[controller]")]

public class OkController : Controller
{

    [HttpGet]
    [Authorize(Roles="admin, jefe")]
    public IActionResult Get()
    {
        return Ok();
    }



}

