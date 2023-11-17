using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

[ApiController]
[Route("API/bascula")]
public class BasculaController: ControllerBase
{
    public readonly MyContext context;

    public BasculaController(MyContext context)
    {
        this.context=context;
    }

    [HttpPost]
    public async Task<ActionResult>Post(Bascula bascula)
    {
        context.Add(bascula);
        await context.SaveChangesAsync(); //insertar en la tabla de generos
        return Ok();
    }
    [HttpGet]
    public IEnumerable<Bascula>Get() => context.Basculas.ToList();

}
