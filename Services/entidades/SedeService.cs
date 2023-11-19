using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class SedeService
{
    private readonly MyContext _context;

    public SedeService(MyContext context)
    {
        _context = context;
    }

    public async Task<Sede> Get(int id)
    {
        var current_entity = await _context.Sedes.FindAsync(id);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }


    public async Task<IEnumerable<Sede>> GetAll()
    {
        return await _context.Sedes.ToListAsync();
    }

    public async Task<Sede> Update(int id,Sede sede)
    {
        var sedeExistente = await Get(id);
        
        await _context.SaveChangesAsync();

        return sede;
    }

    public async Task<Sede> Create(Sede sede)
    {
        _context.Sedes.Add(sede);
        await _context.SaveChangesAsync();

        return sede;
    }

    public async Task Delete(int id)
    {
        var sede = await Get(id);

        if (sede == null)
        {
            return;
        }

        _context.Sedes.Remove(sede);
        await _context.SaveChangesAsync();
    }

    
}
