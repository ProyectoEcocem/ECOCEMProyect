using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class OrdenTrabajoHerramientaServicio
{
    private readonly MyContext _context;

    public OrdenTrabajoHerramientaServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<OrdenTrabajoHerramienta> Get(int HerramientasId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId )
    {
        //var current_entity = await _context.FindAsync<Bascula>(id);
        var current_entity = await _context.OrdenTrabajoHerramientas.FindAsync(HerramientasId,EquipoId,BrigadaId,TrabajadorId,FechaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<OrdenTrabajoHerramienta>> GetAll()
    {
        return await _context.OrdenTrabajoHerramientas.ToListAsync();
    }
    public async Task<OrdenTrabajoHerramienta> Update(int HerramientasId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId,OrdenTrabajoHerramienta ordenTrabajoHerramienta)
    {
        var OrdenTrabajoHerramientaExistente = await Get(HerramientasId,EquipoId,BrigadaId,TrabajadorId,FechaId);

        if (OrdenTrabajoHerramientaExistente == null)
        {
            return null!;
        }
        
        await _context.SaveChangesAsync();

        return ordenTrabajoHerramienta;
    }
    public async Task<OrdenTrabajoHerramienta> Create(OrdenTrabajoHerramienta ordenTrabajoHerramienta)
    {
        _context.OrdenTrabajoHerramientas.Add(ordenTrabajoHerramienta);
        await _context.SaveChangesAsync();

        return ordenTrabajoHerramienta;
    }
     public async Task Delete(int HerramientasId,int EquipoId,int BrigadaId,int TrabajadorId,DateTime FechaId)
    {
        var ordenTrabajoHerramienta = await Get(HerramientasId,EquipoId,BrigadaId,TrabajadorId,FechaId);

        if (ordenTrabajoHerramienta == null)
        {
            return;
        }

        _context.OrdenTrabajoHerramientas.Remove(ordenTrabajoHerramienta);
        await _context.SaveChangesAsync();
    }


}
