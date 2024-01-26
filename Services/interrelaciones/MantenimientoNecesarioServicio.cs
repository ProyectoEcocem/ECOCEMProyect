using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class MantenimientoNecesarioServicio
{
    private readonly MyContext _context;

    public MantenimientoNecesarioServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<MantenimientoNecesario> Get(int TipoEquipoId,int AMId,double HorasExpId)
    {
        var current_entity = await _context.MantenimientosNecesarios.FindAsync(TipoEquipoId,AMId,HorasExpId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<MantenimientoNecesario>> GetAll()
    {
        return await _context.MantenimientosNecesarios.ToListAsync();
    }
    public async Task<MantenimientoNecesario> Update(int TipoEquipoId,int AMId,double HorasExpId, MantenimientoNecesario MN)
    {
        var MNExistente = await Get(TipoEquipoId,AMId,HorasExpId);

        if (MNExistente== null)
        {
            return null;
        }
        
       
        await _context.SaveChangesAsync();

        return MN;
    }
    public async Task<MantenimientoNecesario> Create(MantenimientoNecesario MN)
    {
        _context.MantenimientosNecesarios.Add(MN);
        await _context.SaveChangesAsync();

        return MN;
    }
     public async Task Delete(int TipoEquipoId,int AMId,double HorasExpId)
    {
        var MN = await Get(TipoEquipoId,AMId,HorasExpId);

        if (MN == null)
        {
            return;
        }

        _context.MantenimientosNecesarios.Remove(MN);
        await _context.SaveChangesAsync();
    }


}
