using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class RoturaEquipoServicio
{
    private readonly MyContext _context;

    public RoturaEquipoServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<RoturaEquipo> Get(int RoturaId,int EquipoId,DateTime FechaId)
    {
        
        
        var current_entity = await _context.RoturasEquipos.FindAsync(RoturaId,EquipoId,FechaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<RoturaEquipo>> GetAll()
    {
        return await _context.RoturasEquipos.ToListAsync();
    }
    public async Task<RoturaEquipo> Update(int RoturaId,int EquipoId,DateTime FechaId,RoturaEquipo roturaE)
    {
        var roturaEExistente = await Get(RoturaId,EquipoId,FechaId);

        if (roturaEExistente== null)
        {
            return null!;
        }
    
       
        await _context.SaveChangesAsync();

        return roturaE;
    }
    public async Task<RoturaEquipo> Create(RoturaEquipo roturaE)
    {
        _context.RoturasEquipos.Add(roturaE);
        await _context.SaveChangesAsync();

        return roturaE;
    }
     public async Task Delete(int RoturaId,int EquipoId,DateTime FechaId)
    {
        var roturaE = await Get(RoturaId,EquipoId,FechaId);

        if (roturaE == null)
        {
            return;
        }

        _context.RoturasEquipos.Remove(roturaE);
        await _context.SaveChangesAsync();
    }


}
