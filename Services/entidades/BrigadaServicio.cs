using Microsoft.EntityFrameworkCore;

namespace ECOCEMProject;

public class BrigadaServicio
{
    private readonly MyContext _context;

    public BrigadaServicio(MyContext context)
    {
        _context = context;
    }

    public async Task<Brigada> Get(int id)
    {
        var current_entity = await _context.Brigadas.FindAsync(id);
        if (current_entity == null)
        {
            return null!;
        }
        return current_entity;
    }

    public async Task<IEnumerable<Brigada>> GetAll()
    {
        return await _context.Brigadas.ToListAsync();
    }

    public async Task<Brigada> Update(int id, Brigada brigada)
    {
        var brigadaExistente = await Get(id);
        if (brigadaExistente == null)
        {
            return null!;
        }
        brigadaExistente.BrigadaId = brigada.BrigadaId;
        await _context.SaveChangesAsync();
        return brigada;
    }

    public async Task<Brigada> Create(BrigadaData brigada)
    {
        Brigada b = new Brigada();

        b.BrigadaId = brigada.BrigadaId;
        b.Descripcion = brigada.Descripcion;

        _context.Brigadas.Add(b);
        await _context.SaveChangesAsync();
        return b;
    }

    public async Task Delete(int id)
    {
        var brigada= await Get(id);
        if (brigada == null)
        {
            return;
        }
        _context.Brigadas.Remove(brigada);
        await _context.SaveChangesAsync();
    }
}
