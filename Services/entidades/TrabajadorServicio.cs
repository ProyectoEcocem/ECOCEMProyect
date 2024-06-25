using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;
public class TrabajadorServicio
{
    private readonly MyContext _context;
    public TrabajadorServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<Trabajador> Get(int id)
    {
        var current_entity = await _context.Trabajadores.FindAsync(id);
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<Trabajador>> GetAll()
    {
        return await _context.Trabajadores.ToListAsync();
    }
    public async Task<IEnumerable<Trabajador>> GetAll(int sedeId)
    {
        return await _context.Trabajadores.Where(e => e.SedeId == sedeId).ToListAsync();
    }
    public async Task<Trabajador> Update(int id, Trabajador trabajador)
    {
        var trabajadorExistente = await Get(id);
        if (trabajadorExistente == null)
        {
            return null!;
        }
        await _context.SaveChangesAsync();
        return trabajador;
    }
    public async Task<Trabajador> Create(TrabajadorData trabajador, int NoSede)
    {
        if(_context.Trabajadores.Any(elemento => elemento.NombreTrabajador == trabajador.NombreTrabajador))
            return null!;

        Trabajador trabajador1= new Trabajador();
        trabajador1.TrabajadorId=trabajador.TrabajadorId;
        trabajador1.NombreTrabajador=trabajador.NombreTrabajador;
        trabajador1.SedeId=NoSede;

        _context.Trabajadores.Add(trabajador1);
        await _context.SaveChangesAsync();
        return trabajador1;
    }
    public async Task Delete(int id)
    {
        var trabajador = await Get(id);
        if (trabajador == null)
        {
            return;
        }
        _context.Trabajadores.Remove(trabajador);
        await _context.SaveChangesAsync();
    }
}