using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class VentaServicio
{
    private readonly MyContext _context;

    public VentaServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<Venta> Get(int SedeId,int EntidadCompradoraId,DateTime FechaVentaId)
    {
        
        var current_entity = await _context.Ventas.FindAsync(SedeId,EntidadCompradoraId,FechaVentaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<VentaDto>> GetAll()
    {
        return await (from v in _context.Ventas
                          join ec in _context.EntidadCompradoras on v.EntidadCompradoraId equals ec.EntidadCompradoraId
                          select new VentaDto
                          {
                              SedeId = v.SedeId,
                              EntidadCompradoraId = ec.EntidadCompradoraId,
                              NombreEntidadCompradora = ec.NombreEntidadCompradora ?? string.Empty,
                              FechaVentaId = v.FechaVentaId
                          }).ToListAsync();
    }

    public async Task<IEnumerable<VentaDto>> GetAll(int sedeId)
    {
        return await (from v in _context.Ventas
                          join ec in _context.EntidadCompradoras on v.EntidadCompradoraId equals ec.EntidadCompradoraId
                          where v.SedeId == sedeId
                          select new VentaDto
                          {
                              SedeId = v.SedeId,
                              EntidadCompradoraId = ec.EntidadCompradoraId,
                              NombreEntidadCompradora = ec.NombreEntidadCompradora ?? string.Empty,
                              FechaVentaId = v.FechaVentaId
                          }).ToListAsync();
    }
    public async Task<Venta> Update(int SedeId,int EntidadCompradoraId,DateTime FechaVentaId,Venta venta)
    {
        var VentaExistente = await Get(SedeId,EntidadCompradoraId,FechaVentaId);

        if (VentaExistente == null)
        {
            return null;
        }
        
       
        await _context.SaveChangesAsync();

        return venta;
    }
    public async Task<Venta> Create(VentaData venta, int NoSede)
    {
        if(_context.Ventas.Any(elemento => elemento.SedeId == venta.SedeId && elemento.EntidadCompradoraId== venta.EntidadCompradoraId && elemento.FechaVentaId==venta.FechaId))
            return null!;
            
        Venta f1 = new Venta();

        f1.SedeId = NoSede;
        f1.EntidadCompradoraId = venta.EntidadCompradoraId;
        f1.FechaVentaId = venta.FechaId;

        _context.Ventas.Add(f1);
        await _context.SaveChangesAsync();
        return f1;
    }
     public async Task Delete(int SedeId,int EntidadCompradoraId,DateTime FechaVentaId)
    {
        var venta = await Get(SedeId,EntidadCompradoraId,FechaVentaId);

        if (venta == null)
        {
            return;
        }

        _context.Ventas.Remove(venta);
        await _context.SaveChangesAsync();
    }


}
