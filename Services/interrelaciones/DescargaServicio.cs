using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class DescargaServicio
{
    private readonly MyContext _context;

    public DescargaServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<Descarga> Get(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaId)
    {
        //var current_entity = await _context.FindAsync<Bascula>(id);
        var current_entity = await _context.Descargas.FindAsync(TipoCementoId,SiloId,VehiculoId,FechaId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<Descarga>> GetAll()
    {
        return await _context.Descargas.ToListAsync();
    }

    public async Task<IEnumerable<Descarga>> GetAll(int sedeId)
    {
        return await _context.Descargas.Where(d =>d.SedeId ==  sedeId).ToListAsync();
    }

    public async Task<Descarga> Update(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaId,Descarga descarga)
    {
        var DescargaExistente = await Get(TipoCementoId,SiloId,VehiculoId,FechaId);

        if (DescargaExistente == null)
        {
            return null!;
        }
        
        //existingBascula.BasculaId = bascula.BasculaId;
        await _context.SaveChangesAsync();

        return descarga;
    }
    public async Task<Descarga> Create(DescargaData descarga)
    {
         if(_context.Descargas.Any(elemento => elemento.TipoCementoId == descarga.TipoCementoId && elemento.SiloId== descarga.SiloId && elemento.FechaId==descarga.FechaId && elemento.VehiculoId==descarga.VehiculoId))
            return null!;
            
        Descarga d = new Descarga();
        MedicionSilo ms = new MedicionSilo();
        MedicionBascula mb = new MedicionBascula();

        //creacion de descarga
        d.DescargaId = descarga.DescargaId;
        d.TipoCementoId = descarga.TipoCementoId;
        d.SiloId = descarga.SiloId;
        d.VehiculoId = descarga.VehiculoId;
        d.FechaId = descarga.FechaId;
        d.PesoBruto = descarga.PesoBruto;
        d.Tara = descarga.Tara;
        d.Temperatura = descarga.Temperatura;
        d.TipoAsentamiento = descarga.TipoAsentamiento;
        d.Corriente = descarga.Corriente;

        //creacion de medicion bascula
        mb.VehiculoId = descarga.VehiculoId;
        mb.BasculaId = descarga.BasculaId;
        mb.FechaBId = descarga.FechaId;
        mb.PesoB = descarga.PesoB;

        //creacion de medicion silo
        ms.SiloId = descarga.SiloId;
        ms.MedidorId = descarga.MedidorId;
        ms.FechaMId = descarga.FechaId;
        ms.Nivel = descarga.Nivel;
        ms.PesoM = descarga.PesoM;
        // ms.Volumen = descarga.Volumen;
        

        _context.Descargas.Add(d);
        _context.MedicionesSilos.Add(ms);
        _context.MedicionesBasculas.Add(mb);
        await _context.SaveChangesAsync();
        return d;
    }
     public async Task Delete(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaId)
    {
        var descarga = await Get(TipoCementoId,SiloId,VehiculoId,FechaId);

        if (descarga == null)
        {
            return;
        }

        _context.Descargas.Remove(descarga);
        await _context.SaveChangesAsync();
    }


}
