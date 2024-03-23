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

    public async Task<List<RoturaEquipo>> GetAll(int sedeId)
{
    var roturasEquipo = await _context.RoturasEquipos
        .Join(_context.Equipos,
            re => re.EquipoId, 
            e => e.EquipoId, 
            (re, e) => new { RoturaEquipo = re, Equipo = e })
        .Where(x => x.Equipo.SedeId == sedeId)
        .Select(x => x.RoturaEquipo)
        .ToListAsync();

    return roturasEquipo;
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
    public async Task<RoturaEquipo> Create(RoturaEquipoData roturaE)
    {
         if(_context.RoturasEquipos.Any(elemento => elemento.EquipoId == roturaE.EquipoId && elemento.RoturaId== roturaE.RoturaId && elemento.FechaId==roturaE.FechaId))
            return null!;
            
        RoturaEquipo f1 = new RoturaEquipo();

        f1.RoturaId = roturaE.RoturaId;
        f1.EquipoId = roturaE.EquipoId;
        f1.FechaId = roturaE.FechaId;

        _context.RoturasEquipos.Add(f1);
        await _context.SaveChangesAsync();
        return f1;
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
