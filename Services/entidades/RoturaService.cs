using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class RoturaService
{
    private readonly MyContext _context;

    public RoturaService(MyContext context)
    {
        _context = context;
    }

    public async Task<Rotura> Get(int id)
    {
        var current_entity = await _context.Roturas.FindAsync(id);
        if (current_entity == null)
        {
            return null;
        }
        return current_entity;
    }

    public async Task<IEnumerable<Rotura>> GetAll()
    {
        return await _context.Roturas.ToListAsync();
    }

    public async Task<Rotura> Update(int id, Rotura rotura)
    {
        var existingRotura = await Get(id);
        if (existingRotura == null)
        {
            return null;
        }
        existingRotura.RoturaId = rotura.RoturaId;
        await _context.SaveChangesAsync();
        return rotura;
    }

    public async Task<Rotura> Create(RoturaData rotura)
    {
         if(_context.Roturas.Any(elemento => elemento.NombreRotura == rotura.NombreRotura))
            return null!;
            
        Rotura f1 = new Rotura();

        f1.RoturaId = rotura.RoturaId;
        f1.NombreRotura = rotura.NombreRotura;
        f1.Descripcion = rotura.Descripcion;

        _context.Roturas.Add(f1);
        await _context.SaveChangesAsync();
        return f1;
    }

    public async Task Delete(int id)
    {
        var rotura = await Get(id);
        if (rotura == null)
        {
            return;
        }
        _context.Roturas.Remove(rotura);
        await _context.SaveChangesAsync();
    }
}
