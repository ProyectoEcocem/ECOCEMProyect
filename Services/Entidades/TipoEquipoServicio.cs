using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;
public class TipoEquipoServicio
{
    private readonly MyContext _context;
    public TipoEquipoServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<TipoEquipo> Get(int id)
    {
        var current_entity = await _context.TiposEquipos.FindAsync(id);
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<TipoEquipo>> GetAll()
    {
        return await _context.TiposEquipos.ToListAsync();
    }
    public async Task<TipoEquipo> Update(int id, TipoEquipo tipoE)
    {
        var tipoEExistente = await Get(id);
        if (tipoEExistente == null)
        {
            return null;
        }
        await _context.SaveChangesAsync();
        return tipoE;
    }
    public async Task<TipoEquipo> Create(TipoEquipo tipoE)
    {
        _context.TiposEquipos.Add(tipoE);
        await _context.SaveChangesAsync();
        return tipoE;
    }
    public async Task Delete(int id)
    {
        var tipoE = await Get(id);
        if (tipoE == null)
        {
            return;
        }
        _context.TiposEquipos.Remove(tipoE);
        await _context.SaveChangesAsync();
    }
}
