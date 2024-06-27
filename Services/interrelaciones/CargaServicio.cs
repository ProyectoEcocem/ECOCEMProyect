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
    public async Task<IEnumerable<CargaDto>> GetAll()
    {
        // return await _context.Cargas.ToListAsync();
        return await (from c in _context.Cargas
                          join t in _context.TipoCementos on c.TipoCementoId equals t.TipoCementoId
                          join s in _context.Silos on c.SiloId equals s.SiloId
                          join v in _context.Vehiculos on c.VehiculoId equals v.VehiculoId
                          join ms in _context.MedicionesSilos on c.FechaCargaId equals ms.FechaMId into msGroup
                          from ms in msGroup.DefaultIfEmpty()
                          join mb in _context.MedicionesBasculas on c.FechaCargaId equals mb.FechaCargaId into mbGroup
                          from mb in mbGroup.DefaultIfEmpty()
                          select new CargaDto
                          {
                              NombreTipoCemento = t.NombreTipoCemento ?? string.Empty,
                              NoSerieSilo = s.NoSilo ?? string.Empty,
                              NoSerieVehiculo = v.NoSerie ?? string.Empty,
                              FechaId = c.FechaCargaId,
                              PesoBruto = c.PesoBruto,
                              Tara = c.Tara,
                              NoSerieMedidor = ms != null ? ms.MedidorId.ToString() : string.Empty, // Assuming the NoSerieMedidor is the SiloId
                              Nivel = ms != null ? ms.Nivel : 0,
                              PesoMedidor = ms != null ? ms.PesoM : 0,
                              Volumen = ms != null ? ms.Volumen : 0,
                              NoSerieBascula = mb != null ? mb.BasculaId.ToString() : string.Empty, // Assuming the NoSerieBascula is the BasculaId
                              PesoBascula = mb != null ? mb.PesoB : 0
                          }).ToListAsync();
    }

    public async Task<IEnumerable<CargaDto>> GetAll(int sedeId)
    {
        return await (from c in _context.Cargas
                          join t in _context.TipoCementos on c.TipoCementoId equals t.TipoCementoId
                          join s in _context.Silos on c.SiloId equals s.SiloId
                          join v in _context.Vehiculos on c.VehiculoId equals v.VehiculoId
                          join vt in _context.Ventas on new { c.SedeId, c.EntidadCompradoraId, c.FechaVentaId } equals new { vt.SedeId, vt.EntidadCompradoraId, vt.FechaVentaId }
                          join ms in _context.MedicionesSilos on c.FechaCargaId equals ms.FechaMId into msGroup
                          from ms in msGroup.DefaultIfEmpty()
                          join mb in _context.MedicionesBasculas on c.FechaCargaId equals mb.FechaCargaId into mbGroup
                          from mb in mbGroup.DefaultIfEmpty()
                          where c.SedeId == sedeId
                          select new CargaDto
                          {
                              NombreTipoCemento = t.NombreTipoCemento ?? string.Empty,
                              NoSerieSilo = s.NoSilo ?? string.Empty,
                              NoSerieVehiculo = v.NoSerie ?? string.Empty,
                              FechaId = c.FechaCargaId,
                              PesoBruto = c.PesoBruto,
                              Tara = c.Tara,
                              NoSerieMedidor = ms != null ? ms.SiloId.ToString() : string.Empty, // Assuming the NoSerieMedidor is the SiloId
                              Nivel = ms != null ? ms.Nivel : 0,
                              PesoMedidor = ms != null ? ms.PesoM : 0,
                              Volumen = ms != null ? ms.Volumen : 0,
                              NoSerieBascula = mb != null ? mb.BasculaId.ToString() : string.Empty, // Assuming the NoSerieBascula is the BasculaId
                              PesoBascula = mb != null ? mb.PesoB : 0
                          }).ToListAsync();
        
    }

    public async Task<Carga> Update(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId,Carga ordenTrabajoHerramienta)
    {
        var CargaExistente = await Get(TipoCementoId,SiloId,VehiculoId,FechaCargaId);

        if (CargaExistente == null)
        {
            return null!;
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
        d.CargaId = carga.CargaId;
        d.TipoCementoId = carga.TipoCementoId;
        d.SiloId = carga.SiloId;
        d.VehiculoId = carga.VehiculoId;
        d.FechaCargaId = carga.FechaId;
        d.PesoBruto = carga.PesoBruto;
        d.Tara = carga.Tara;

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
        // ms.Volumen = carga.Volumen;
        

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
