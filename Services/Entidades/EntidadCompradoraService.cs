using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;
public class EntidadCompradoraService
{
    private readonly MyContext _context;
    public EntidadCompradoraService(MyContext context)
    {
        _context = context;
    }
    public async Task<EntidadCompradora> Get(int id)
    {
        var current_entity = await _context.EntidadCompradoras.FindAsync(id);
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<EntidadCompradora>> GetAll()
    {
        return await _context.EntidadCompradoras.ToListAsync();
    }
    public async Task<EntidadCompradora> Update(int id, EntidadCompradora entidadCompradora)
    {
        var existingEntidadCompradora = await Get(id);
        if (existingEntidadCompradora == null)
        {
            return null;
        }
        await _context.SaveChangesAsync();
        return entidadCompradora;
    }
    public async Task<EntidadCompradora> Create(EntidadCompradora entidadCompradora)
    {
        _context.EntidadCompradoras.Add(entidadCompradora);
        await _context.SaveChangesAsync();
        return entidadCompradora;
    }
    public async Task Delete(int id)
    {
        var entidadCompradora = await Get(id);
        if (entidadCompradora == null)
        {
            return;
        }
        _context.EntidadCompradoras.Remove(entidadCompradora);
        await _context.SaveChangesAsync();
    }
}