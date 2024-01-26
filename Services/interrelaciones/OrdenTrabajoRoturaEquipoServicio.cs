using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class OrdenTrabajoRoturaEquipoServicio
{
    private readonly MyContext _context;

    public OrdenTrabajoRoturaEquipoServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<OrdenTrabajoRoturaEquipo> Get(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,int RoturaId)
    {
        //var current_entity = await _context.FindAsync<Bascula>(id);
        var current_entity = await _context.OrdenTrabajoRoturaEquipos.FindAsync(EquipoId,BrigadaId,TrabajadorId,FechaId,RoturaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<OrdenTrabajoRoturaEquipo>> GetAll()
    {
        return await _context.OrdenTrabajoRoturaEquipos.ToListAsync();
    }
    public async Task<OrdenTrabajoRoturaEquipo> Update(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,int RoturaId,OrdenTrabajoRoturaEquipo ordenTrabajoRoturaEquipo)
    {
        var ordenTrabajoRoturaEquipoExistente = await Get(EquipoId,BrigadaId,TrabajadorId,FechaId,RoturaId);

        if (ordenTrabajoRoturaEquipoExistente == null)
        {
            return null;
        }
        
        await _context.SaveChangesAsync();

        return ordenTrabajoRoturaEquipo;
    }
    public async Task<OrdenTrabajoRoturaEquipo> Create(OrdenTrabajoRoturaEquipo ordenTrabajoRoturaEquipo)
    {
        _context.OrdenTrabajoRoturaEquipos.Add(ordenTrabajoRoturaEquipo);
        await _context.SaveChangesAsync();

        return ordenTrabajoRoturaEquipo;
    }
     public async Task Delete(int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,int RoturaId)
    {
        var ordenTrabajoRoturaEquipo = await Get(EquipoId,BrigadaId,TrabajadorId,FechaId,RoturaId);

        if (ordenTrabajoRoturaEquipo == null)
        {
            return;
        }

        _context.OrdenTrabajoRoturaEquipos.Remove(ordenTrabajoRoturaEquipo);
        await _context.SaveChangesAsync();
    }


}
