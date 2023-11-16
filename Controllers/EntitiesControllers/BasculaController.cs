using ECOCEMProyect.migrations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ECOCEMProyect.Services;


namespace ECOCEMProyect.Controllers;

[ApiController]
[Route("API/bascula")]

public class BasculaController : ControllerBase
{
    private readonly BasculaService _basculaService;

    public BasculaController(BasculaService basculaService)
    {
        _basculaService = basculaService;
    }

    // POST
    [HttpPost]
    public async Task<ActionResult> Post(Bascula bascula)
    {
        return Ok(await _basculaService.CreateBasculaAsync(bascula));
    }

    // GET by ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Bascula>> GetById(int id)
    {
        return await _basculaService.GetBasculaAsync(id);
    }

    // PUT
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(Bascula bascula)
    {
        return Ok(await _basculaService.UpdateBasculaAsync(bascula));
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        return Ok(await _basculaService.DeleteBasculaAsync(id));
    }
}

