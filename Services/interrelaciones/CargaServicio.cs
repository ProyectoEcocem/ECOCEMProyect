using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class CargaServicio
{
    private readonly MyContext _context;

    public CargaServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<Carga> Get(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId)
    {
        //var current_entity = await _context.FindAsync<Bascula>(id);
        var current_entity = await _context.Cargas.FindAsync(TipoCementoId,SiloId,VehiculoId,FechaCargaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<Carga>> GetAll()
    {
        return await _context.Cargas.ToListAsync();
    }

    public async Task<IEnumerable<Carga>> GetAll(int sedeId)
    {
        return await _context.Cargas.Where(c => c.SedeId == sedeId).ToListAsync();
    }

    public async Task<Carga> Update(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId,Carga ordenTrabajoHerramienta)
    {
        var CargaExistente = await Get(TipoCementoId,SiloId,VehiculoId,FechaCargaId);

        if (CargaExistente == null)
        {
            return null;
        }
        
        await _context.SaveChangesAsync();

        return ordenTrabajoHerramienta;
    }
    public async Task<Carga> Create(CargaData carga)
    {
         if(_context.Descargas.Any(elemento => elemento.TipoCementoId == carga.TipoCementoId && elemento.SiloId== carga.SiloId && elemento.FechaId==carga.FechaId && elemento.VehiculoId==carga.VehiculoId))
            return null!;
            
        Carga d = new Carga();
        MedicionSilo ms = new MedicionSilo();
        MedicionBascula mb = new MedicionBascula();
        

        //creacion de carga
        d.TipoCementoId = carga.TipoCementoId;
        d.SiloId = carga.SiloId;
        d.VehiculoId = carga.VehiculoId;
        d.FechaCargaId = carga.FechaId;

        //creacion de medicion bascula
        mb.VehiculoId = carga.VehiculoId;
        mb.BasculaId = carga.BasculaId;
        mb.FechaBId = carga.FechaId;
        mb.PesoB = carga.PesoB;

        //creacion de medicion silo
        ms.SiloId = carga.SiloId;
        ms.MedidorId = carga.MedidorId;
        ms.FechaMId = carga.FechaId;
        ms.Nivel = carga.Nivel;
        ms.PesoM = carga.PesoM;
        ms.Volumen = carga.Volumen;
        

        _context.Cargas.Add(d);
        _context.MedicionesSilos.Add(ms);
        _context.MedicionesBasculas.Add(mb);
        await _context.SaveChangesAsync();
        return d;
    }
     public async Task Delete(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId)
    {
        var ordenTrabajoHerramienta = await Get(TipoCementoId,SiloId,VehiculoId,FechaCargaId);

        if (ordenTrabajoHerramienta == null)
        {
            return;
        }

        _context.Cargas.Remove(ordenTrabajoHerramienta);
        await _context.SaveChangesAsync();
    }


}
