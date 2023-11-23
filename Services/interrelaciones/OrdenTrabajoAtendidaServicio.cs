using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;
   

public class OrdenTrabajoAtendidaServicio
{
    private readonly MyContext _context;

    public OrdenTrabajoAtendidaServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<OrdenTrabajoAtendida> Get(int EquipoId , int BrigadaId, int TrabajadorId, DateTime FechaId, DateTime DiaId)
    {
        
        var current_entity = await _context.OrdenesTrabajoAtendidas.FindAsync(EquipoId ,BrigadaId,TrabajadorId,FechaId,DiaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<OrdenTrabajoAtendida>> GetAll()
    {
        return await _context.OrdenesTrabajoAtendidas.ToListAsync();
    }
    public async Task<OrdenTrabajoAtendida> Update(int EquipoId , int BrigadaId, int TrabajadorId, DateTime FechaId,DateTime DiaId,OrdenTrabajoAtendida ordenTA)
    {
        var ordenTAExistente = await Get(EquipoId ,BrigadaId,TrabajadorId,FechaId,DiaId);

        if (ordenTAExistente == null)
        {
            return null;
        }
        
       
        await _context.SaveChangesAsync();

        return ordenTA;
    }
    public async Task<OrdenTrabajoAtendida> Create(OrdenTrabajoAtendida ordenTA)
    {
        _context.OrdenesTrabajoAtendidas.Add(ordenTA);
        await _context.SaveChangesAsync();

        return ordenTA;
    }
     public async Task Delete(int EquipoId , int BrigadaId, int TrabajadorId, DateTime FechaId,DateTime DiaId)
    {
        var ordenTA = await Get(EquipoId ,BrigadaId,TrabajadorId,FechaId,DiaId);

        if (ordenTA == null)
        {
            return;
        }

        _context.OrdenesTrabajoAtendidas.Remove(ordenTA);
        await _context.SaveChangesAsync();
    }


}
