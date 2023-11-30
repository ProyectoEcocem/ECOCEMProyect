using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;
public class TipoCementoService
{
    private readonly MyContext _context;

    public TipoCementoService(MyContext context)
    {
        _context = context;
    }

    public async Task<TipoCemento> Get(int id)
    {
        var current_entity = await _context.TipoCementos.FindAsync(id);
        if (current_entity == null)
        {
            return null;
        }
        return current_entity;
    }

    public async Task<IEnumerable<TipoCemento>> GetAll()
    {
        return await _context.TipoCementos.ToListAsync();
    }

    public async Task<TipoCemento> Update(int id, TipoCemento tipoCemento)
    {
        var existingTipoCemento = await Get(id);
        if (existingTipoCemento == null)
        {
            return null;
        }
        existingTipoCemento.TipoCementoId = tipoCemento.TipoCementoId;
        await _context.SaveChangesAsync();
        return tipoCemento;
    }

    public async Task<TipoCemento> Create(TipoCemento tipoCemento)
    {
        _context.TipoCementos.Add(tipoCemento);
        await _context.SaveChangesAsync();
        return tipoCemento;
    }

    public async Task Delete(int id)
    {
        var tipoCemento = await Get(id);
        if (tipoCemento == null)
        {
            return;
        }
        _context.TipoCementos.Remove(tipoCemento);
        await _context.SaveChangesAsync();
    }
}
