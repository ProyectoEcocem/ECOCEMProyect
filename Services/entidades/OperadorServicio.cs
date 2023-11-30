using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class OperadorServicio
{
    private readonly MyContext _context;

    public OperadorServicio(MyContext context)
    {
        _context = context;
    }

    public async Task<Operador> Get(int id)
    {
        var current_entity = await _context.Operadores.FindAsync(id);
        if (current_entity == null)
        {
            return null;
        }
        return current_entity;
    }

    public async Task<IEnumerable<Operador>> GetAll()
    {
        return await _context.Operadores.ToListAsync();
    }

    public async Task<Operador> Update(int id, Operador operador)
    {
        var operadorExistente = await Get(id);
        if (operadorExistente == null)
        {
            return null;
        }
        operadorExistente.TrabajadorId = operador.TrabajadorId;
        await _context.SaveChangesAsync();
        return operador;
    }

    public async Task<Operador> Create(Operador operador)
    {
        _context.Operadores.Add(operador);
        await _context.SaveChangesAsync();
        return operador;
    }

    public async Task Delete(int id)
    {
        var operador = await Get(id);
        if (operador == null)
        {
            return;
        }
        _context.Operadores.Remove(operador);
        await _context.SaveChangesAsync();
    }
}
