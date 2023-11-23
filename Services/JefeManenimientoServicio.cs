using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class JefeMantenimientoServicio
{
    private readonly MyContext _context;

    public JefeMantenimientoServicio(MyContext context)
    {
        _context = context;
    }

    public async Task<JefeMantenimiento> Get(int id)
    {
        var current_entity = await _context.JefesMantenimientos.FindAsync(id);
        if (current_entity == null)
        {
            return null;
        }
        return current_entity;
    }

    public async Task<IEnumerable<JefeMantenimiento>> GetAll()
    {
        return await _context.JefesMantenimientos.ToListAsync();
    }

    public async Task<JefeMantenimiento> Update(int id, JefeMantenimiento jefeMantenimiento)
    {
        var jefeMExistente = await Get(id);
        if (jefeMExistente == null)
        {
            return null;
        }
        //jefeMExistente.TrabajadorId = jefeMantenimiento.TrabajadorId;
        await _context.SaveChangesAsync();
        return jefeMantenimiento;
    }

    public async Task<JefeMantenimiento> Create(JefeMantenimiento jefeMantenimiento)
    {
        _context.JefesMantenimientos.Add(jefeMantenimiento);
        await _context.SaveChangesAsync();
        return jefeMantenimiento;
    }

    public async Task Delete(int id)
    {
        var jefeMantenimiento = await Get(id);
        if (jefeMantenimiento == null)
        {
            return;
        }
        _context.JefesMantenimientos.Remove(jefeMantenimiento);
        await _context.SaveChangesAsync();
    }
}
