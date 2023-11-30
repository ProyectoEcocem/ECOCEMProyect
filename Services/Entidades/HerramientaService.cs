using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class HerramientaService
{
    private readonly MyContext _context;

    public HerramientaService(MyContext context)
    {
        _context = context;
    }

    public async Task<Herramienta> Get(int id)
    {
        //var current_entity = await _context.FindAsync<Bascula>(id);
        var current_entity = await _context.Herramientas.FindAsync(id);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }


    public async Task<IEnumerable<Herramienta>> GetAll()
    {
        return await _context.Herramientas.ToListAsync();
    }

    public async Task<Herramienta> Update(int id,Herramienta herramienta)
    {
        var herramientaExistente = await Get(id);

        if (herramientaExistente == null)
        {
            return null;
        }
        
        //existingBascula.BasculaId = bascula.BasculaId;
        await _context.SaveChangesAsync();

        return herramienta;
    }

    public async Task<Herramienta> Create(Herramienta herramienta)
    {
        _context.Herramientas.Add(herramienta);
        await _context.SaveChangesAsync();

        return herramienta;
    }

    public async Task Delete(int id)
    {
        var herramienta = await Get(id);

        if (herramienta == null)
        {
            return;
        }

        _context.Herramientas.Remove(herramienta);
        await _context.SaveChangesAsync();
    }
}