using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;
public class EquipoServicio
{
    private readonly MyContext _context;
    public EquipoServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<Equipo> Get(int id)
    {
        var current_entity = await _context.Equipos.FindAsync(id);
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<EquipoDto>> GetAll()
    {
        return await (from e in _context.Equipos
                      join te in _context.TiposEquipos on e.TipoEId equals te.TipoEId
                      join s in _context.Sedes on e.SedeId equals s.SedeId
                      select new EquipoDto
                      {
                          EquipoId = e.EquipoId,
                          TipoEquipoNombre = te.TipoE!,
                          SedeNombre = s.NombreSede!
                      }).ToListAsync();
    }

    public async Task<IEnumerable<EquipoDto>> GetAll(int sedeId)
    {
        return await (from e in _context.Equipos
                      join te in _context.TiposEquipos on e.TipoEId equals te.TipoEId
                      join s in _context.Sedes on e.SedeId equals s.SedeId
                      where e.SedeId == sedeId
                      select new EquipoDto
                      {
                          EquipoId = e.EquipoId,
                          TipoEquipoNombre = te.TipoE!,
                          SedeNombre = s.NombreSede ?? string.Empty
                      }).ToListAsync();
    }
    public async Task<Equipo> Update(int id, Equipo equipo)
    {
        var equipoExistente = await Get(id);
        if (equipoExistente == null)
        {
            return null!;
        }
        await _context.SaveChangesAsync();
        return equipo;
    }
    public async Task<Equipo> Create(EquipoData equipo, int NoSede)
    {
        if(_context.Equipos.Any(elemento => elemento.SedeId == NoSede || elemento.EquipoId == equipo.EquipoId || elemento.TipoEId==equipo.TipoEId))
            return null!;

        Equipo equipo1 = new Equipo();

        equipo1.SedeId = NoSede;
        equipo1.EquipoId = equipo.EquipoId;
        equipo1.TipoEId = equipo.TipoEId;

        _context.Equipos.Add(equipo1);
        await _context.SaveChangesAsync();

        return equipo1;
    }
    public async Task Delete(int id)
    {
        var equipo = await Get(id);
        if (equipo == null)
        {
            return;
        }
        _context.Equipos.Remove(equipo);
        await _context.SaveChangesAsync();
    }
}