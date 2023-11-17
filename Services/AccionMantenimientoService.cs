namespace ECOCEMProject;

public class AccionMantenimientoService
{
    private readonly MyContext _context;

    public AccionMantenimientoService(MyContext context)
    {
        _context = context;
    }

    public async Task<AccionMantenimiento> CreateAccionMantenimientoAsync(AccionMantenimiento accionMantenimiento)
    {
        _context.AccionesMantenimientos.Add(accionMantenimiento);
        await _context.SaveChangesAsync();

        return accionMantenimiento;
    }

    public async Task<AccionMantenimiento> GetAccionMantenimientoAsync(int id)
    {
        return await _context.AccionesMantenimientos.FindAsync(id);
    }

    public async Task<AccionMantenimiento> UpdateAccionMantenimientoAsync(AccionMantenimiento accionMantenimiento)
    {
        AccionMantenimiento accionMantenimientoActualizada = await _context.AccionesMantenimientos.FindAsync(accionMantenimiento.AMId);

        if (accionMantenimientoActualizada == null)
        {
            return null;
        }

        _context.Entry(accionMantenimientoActualizada).CurrentValues.SetValues(accionMantenimiento);
        await _context.SaveChangesAsync();

        return accionMantenimientoActualizada;
    }

    public async Task<bool> DeleteAccionMantenimientoAsync(int id)
    {
        AccionMantenimiento accionMantenimiento = await _context.AccionesMantenimientos.FindAsync(id);

        if (accionMantenimiento == null)
        {
            return false;
        }

        _context.AccionesMantenimientos.Remove(accionMantenimiento);
        await _context.SaveChangesAsync();

        return true;
    }
}
