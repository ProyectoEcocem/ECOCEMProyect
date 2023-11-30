using Microsoft.EntityFrameworkCore;

namespace ECOCEMProject;

public class FabricaService
{
    private readonly MyContext _context;

    public FabricaService(MyContext context)
    {
        _context = context;
    }

    public async Task<Fabrica> Get(int id)
    {
        var current_entity = await _context.Fabricas.FindAsync(id);
        if (current_entity == null)
        {
            return null;
        }
        return current_entity;
    }

    public async Task<IEnumerable<Fabrica>> GetAll()
    {
        return await _context.Fabricas.ToListAsync();
    }

    public async Task<Fabrica> Update(int id, Fabrica fabrica)
    {
        var existingFabrica = await Get(id);
        if (existingFabrica == null)
        {
            return null;
        }
        existingFabrica.FabricaId = fabrica.FabricaId;
        await _context.SaveChangesAsync();
        return fabrica;
    }

    public async Task<Fabrica> Create(Fabrica fabrica)
    {
        _context.Fabricas.Add(fabrica);
        await _context.SaveChangesAsync();
        return fabrica;
    }

    public async Task Delete(int id)
    {
        var fabrica = await Get(id);
        if (fabrica == null)
        {
            return;
        }
        _context.Fabricas.Remove(fabrica);
        await _context.SaveChangesAsync();
    }
}
