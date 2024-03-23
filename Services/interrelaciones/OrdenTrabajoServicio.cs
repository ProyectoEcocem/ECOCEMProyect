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

    public async Task<List<OrdenTrabajo>> GetAll(int sedeId)
{
    var ordenesTrabajo = await _context.OrdenTrabajos
        .Join(_context.Equipos,
            ot => ot.EquipoId, 
            e => e.EquipoId,
            (ot, e) => new { OrdenTrabajo = ot, Equipo = e })
        .Where(x => x.Equipo.SedeId == sedeId)
        .Select(x => x.OrdenTrabajo)
        .ToListAsync();

    return ordenesTrabajo;
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
    public async Task<OrdenTrabajo> Create(OrdenTrabajoData OT)
    {
        OrdenTrabajo ot = new OrdenTrabajo();

        ot.EquipoId = OT.EquipoId;
        ot.BrigadaId = OT.BrigadaId;
        ot.TrabajadorId = OT.TrabajadorId;
        ot.FechaId = OT.FechaId;

        _context.OrdenTrabajos.Add(ot);
        await _context.SaveChangesAsync();

        return ot;
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
