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
        return await _context.Sedes.Include(e=> e.Trabajadores).Include(e=> e.Equipos).ToListAsync();
    }

    public async Task<Sede> Update(int id,Sede sede)
    {
        var sedeExistente = await Get(id);
        
        await _context.SaveChangesAsync();

        return sede;
    }

    public async Task<Sede> Create(SedeData sede)
    {
        if(_context.Sedes.Any(elemento => elemento.NombreSede == sede.nombreSede))
            return null!;

        Sede sede1= new Sede();
        sede1.SedeId=sede.sedeId;
        sede1.NombreSede=sede.nombreSede;
        sede1.EmpresaId=sede.empresaId;
        sede1.UbicacionSede=sede.ubicacionSede;
        
        
        _context.Sedes.Add(sede1);
        await _context.SaveChangesAsync();

        return sede1;
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

    public async Task<IEnumerable<Equipo>> GetEquipos(int id)
    {
        var sedes =  await _context.Sedes.Include(e=> e.Trabajadores).Include(e=> e.Equipos).ToListAsync();
        Sede sede = sedes.FirstOrDefault(s => s.SedeId == id)!;

        if (sede != null)
        {
            return sede.Equipos;
        }
        else
        {
            return null!;
        }
    }

    
}
