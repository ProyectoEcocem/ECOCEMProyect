using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class OrdenTrabajoServicio
{
    private readonly MyContext _context;

    public OrdenTrabajoServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<OrdenTrabajo> Get(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        var current_entity = await _context.OrdenTrabajos.FindAsync(EquipoId,BrigadaId,TrabajadorId, FechaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<OrdenTrabajo>> GetAll()
    {
        return await _context.OrdenTrabajos.ToListAsync();
    }
    public async Task<OrdenTrabajo> Update(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId, OrdenTrabajo OT)
    {
        var OTExistente = await Get(EquipoId,BrigadaId,TrabajadorId,FechaId);

        if (OTExistente== null)
        {
            return null!;
        }
        
       
        await _context.SaveChangesAsync();

        return OT;
    }
    public async Task<OrdenTrabajo> Create(OrdenTrabajo OT)
    {
        _context.OrdenTrabajos.Add(OT);
        await _context.SaveChangesAsync();

        return OT;
    }
     public async Task Delete(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        var OT = await Get(EquipoId,BrigadaId,TrabajadorId,FechaId);

        if (OT == null)
        {
            return;
        }

        _context.OrdenTrabajos.Remove(OT);
        await _context.SaveChangesAsync();
    }


}
