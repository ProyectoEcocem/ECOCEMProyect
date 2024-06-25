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
            return null!;
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
            return null!;
        }
        existingFabrica.FabricaId = fabrica.FabricaId;
        await _context.SaveChangesAsync();
        return fabrica;
    }

    public async Task<Fabrica> Create(FabricaData fabrica)
    {
        if(_context.Fabricas.Any(elemento => elemento.Nombre == fabrica.Nombre))
            return null!;
            
        Fabrica f1 = new Fabrica();

        f1.FabricaId = fabrica.FabricaId;
        f1.Nombre = fabrica.Nombre;

        _context.Fabricas.Add(f1);
        await _context.SaveChangesAsync();
        return f1;
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
