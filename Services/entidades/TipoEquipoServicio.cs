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
        return await _context.TiposEquipos.Include(e=>e.Equipos).ToListAsync();
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

    public async Task<TipoEquipo> Create(TipoEData tipoEq)
    {
        if(_context.TiposEquipos.Any(elemento => elemento.TipoE == tipoEq.TipoE))
            return null!;

        TipoEquipo tipoE1=new TipoEquipo();
        tipoE1.TipoE=tipoEq.TipoE;
        tipoE1.TipoEId=tipoEq.TipoEId;

        _context.TiposEquipos.Add(tipoE1);
        await _context.SaveChangesAsync();
        return tipoE1;
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
