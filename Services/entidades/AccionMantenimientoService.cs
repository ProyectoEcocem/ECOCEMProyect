using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class AccionMantenimientoService
{
    private readonly MyContext _context;

    public AccionMantenimientoService(MyContext context)
    {
        _context = context;
    }
    public async Task<AccionMantenimiento> Get(int id)
    {
        //var current_entity = await _context.FindAsync<Bascula>(id);
        var current_entity = await _context.AccionesMantenimientos.FindAsync(id);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<AccionMantenimiento>> GetAll()
    {
        return await _context.AccionesMantenimientos.ToListAsync();
    }
    public async Task<AccionMantenimiento> Update(int id,AccionMantenimiento accionM)
    {
        var accionMExistente = await Get(id);

        if (accionMExistente == null)
        {
            return null!;
        }
        
        //existingBascula.BasculaId = bascula.BasculaId;
        await _context.SaveChangesAsync();

        return accionM;
    }
    public async Task<AccionMantenimiento> Create(AccionMantenimientoData accionM)
    {
        AccionMantenimiento am = new AccionMantenimiento();

        am.AMId = accionM.AMId;
        am.Descripcion = accionM.Description;

        _context.AccionesMantenimientos.Add(am);
        await _context.SaveChangesAsync();

        return am;
    }
     public async Task Delete(int id)
    {
        var accionM = await Get(id);

        if (accionM == null)
        {
            return;
        }

        _context.AccionesMantenimientos.Remove(accionM);
        await _context.SaveChangesAsync();
    }


}
