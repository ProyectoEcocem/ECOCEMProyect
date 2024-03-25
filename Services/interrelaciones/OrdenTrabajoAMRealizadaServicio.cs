using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class OrdenTrabajoAMRealizadaServicio
{
    private readonly MyContext _context;

    public OrdenTrabajoAMRealizadaServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<OrdenTrabajoAMRealizada> Get(int AMId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        //var current_entity = await _context.FindAsync<Bascula>(id);
        var current_entity = await _context.OrdenTrabajoAMRealizadas.FindAsync(AMId,EquipoId,BrigadaId,TrabajadorId,FechaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<OrdenTrabajoAMRealizada>> GetAll()
    {
        return await _context.OrdenTrabajoAMRealizadas.ToListAsync();
    }
    public async Task<OrdenTrabajoAMRealizada> Update(int AMId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,string resultado, OrdenTrabajoAMRealizada ordenTrabajoAMRealizada)
    {
        var ordenTrabajoAMRealizadaExistente = await Get(AMId,EquipoId,BrigadaId,TrabajadorId,FechaId);

        if (ordenTrabajoAMRealizadaExistente == null)
        {
            return null!;
        }
        
        await _context.SaveChangesAsync();

        return ordenTrabajoAMRealizada;
    }
    public async Task<OrdenTrabajoAMRealizada> Create(OrdenTrabajoAMRealizada ordenTrabajoAMRealizada)
    {
        _context.OrdenTrabajoAMRealizadas.Add(ordenTrabajoAMRealizada);
        await _context.SaveChangesAsync();

        return ordenTrabajoAMRealizada;
    }
     public async Task Delete(int AMId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        var ordenTrabajoAMRealizada = await Get(AMId,EquipoId,BrigadaId,TrabajadorId,FechaId);

        if (ordenTrabajoAMRealizada == null)
        {
            return;
        }

        _context.OrdenTrabajoAMRealizadas.Remove(ordenTrabajoAMRealizada);
        await _context.SaveChangesAsync();
    }


}
