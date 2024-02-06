using Microsoft.EntityFrameworkCore;

namespace ECOCEMProject;

public class SiloServicio
{
    private readonly MyContext _context;

    public SiloServicio(MyContext context)
    {
        _context = context;
    }

    public async Task<Silo> Get(int id)
    {
        var current_entity = await _context.Silos.FindAsync(id);
        if (current_entity == null)
        {
            return null;
        }
        return current_entity;
    }

    public async Task<IEnumerable<Silo>> GetAll()
    {
        return await _context.Silos.ToListAsync();
    }

    public async Task<Silo> Update(int id, Silo silo)
    {
        var siloExistente = await Get(id);
        if (siloExistente == null)
        {
            return null;
        }
        siloExistente.EquipoId = silo.EquipoId;
        await _context.SaveChangesAsync();
        return silo;
    }

    public async Task<Silo> Create(Silo silo)
    {
        _context.Silos.Add(silo);
        await _context.SaveChangesAsync();
        return silo;
    }

    public async Task Delete(int id)
    {
        var silo = await Get(id);
        if (silo == null)
        {
            return;
        }
        _context.Silos.Remove(silo);
        await _context.SaveChangesAsync();
    }
}
