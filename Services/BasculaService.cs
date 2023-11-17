using ECOCEMProyect.migrations;

namespace ECOCEMProyect.Services;

public class BasculaService
{
    private readonly MyContext _context;

    public BasculaService(MyContext context)
    {
        _context = context;
    }

    public async Task<Bascula> CreateBasculaAsync(Bascula bascula)
    {
        _context.Basculas.Add(bascula);
        await _context.SaveChangesAsync();

        return bascula;
    }

    public async Task<Bascula> GetBasculaAsync(int id)
    {
        return await _context.Basculas.FindAsync(id);
    }

    public async Task<Bascula> UpdateBasculaAsync(Bascula bascula)
    {
        Bascula basculaActualizada = await _context.Basculas.FindAsync(bascula.BasculaId);

        if (basculaActualizada == null)
        {
            return null;
        }

        _context.Entry(basculaActualizada).CurrentValues.SetValues(bascula);
        await _context.SaveChangesAsync();

        return basculaActualizada;
    }

    public async Task<bool> DeleteBasculaAsync(int id)
    {
        Bascula bascula = await _context.Basculas.FindAsync(id);

        if (bascula == null)
        {
            return false;
        }

        _context.Basculas.Remove(bascula);
        await _context.SaveChangesAsync();

        return true;
    }
}

