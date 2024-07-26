using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace ECOCEMProject;

public class ReporteServicio
{
    private readonly MyContext _context;

    public ReporteServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<Reporte> Get(int EquipoId,DateTime FechaId)
    {
        
        var current_entity = await _context.Reportes.FindAsync(EquipoId,FechaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<Reporte>> GetAll()
    {
        return await _context.Reportes.ToListAsync();
    }
    public async Task<Reporte> Update(int EquipoId,DateTime FechaId,Reporte reporte)
    {
        var reporteExistente = await Get(EquipoId,FechaId);

        if (reporteExistente == null)
        {
            return null!;
        }
        
       
        await _context.SaveChangesAsync();

        return reporte;
    }
    public async Task<Reporte> Create(Reporte reporte)
    {
        Reporte r = new Reporte();
        r.EquipoId = reporte.EquipoId;
        r.FechaId = reporte.FechaId;
        r.TiempoRealParoFalla = reporte.TiempoRealParoFalla;
        r.TiempoRealMant = reporte.TiempoRealMant;
        r.TiempoOPeracionReal = reporte.TiempoOPeracionReal;
        r.TiempoParoTrabajosPlan = reporte.TiempoParoTrabajosPlan;
        r.TiempoParoMant = reporte.TiempoParoMant;
        r.TiempoOperacionRequerido = reporte.TiempoOperacionRequerido;
        r.TiempoRequeridoAccProgramadas = reporte.TiempoRequeridoAccProgramadas;
        r.CostoTotalMant = reporte.CostoTotalMant;
        r.Facturacion = reporte.Facturacion;
        r.CostoMantContratado = reporte.CostoMantContratado;

        _context.Reportes.Add(r);
        await _context.SaveChangesAsync();

        return reporte;
    }
     public async Task Delete(int EquipoId,DateTime FechaId)
    {
        var reporte = await Get(EquipoId,FechaId);

        if (reporte == null)
        {
            return;
        }

        _context.Reportes.Remove(reporte);
        await _context.SaveChangesAsync();
    }


}
