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
    public async Task<IEnumerable<EquipoRoturaDto>> GetAll()
    {
        return await (from e in _context.Equipos
                join re in _context.RoturasEquipos on e.EquipoId equals re.EquipoId
                join r in _context.Roturas on re.RoturaId equals r.RoturaId
                select new EquipoRoturaDto
                {
                    EquipoId = re.EquipoId,
                    NombreRotura = r.NombreRotura!,
                    FechaId = re.FechaId
                }).ToListAsync();
    }

     public async Task<IEnumerable<EquipoRoturaDto>> GetAll(int sedeId)
    {
        return await (from e in _context.Equipos
                        join re in _context.RoturasEquipos on e.EquipoId equals re.EquipoId
                        join r in _context.Roturas on re.RoturaId equals r.RoturaId
                        where e.SedeId == sedeId
                        select new EquipoRoturaDto
                        {
                            EquipoId = re.EquipoId,
                            NombreRotura = r.NombreRotura!,
                            FechaId = re.FechaId
                        }).ToListAsync();
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
