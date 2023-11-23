using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<Descarga> Update(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaId,Descarga descarga)
    {
        var DescargaExistente = await Get(TipoCementoId,SiloId,VehiculoId,FechaId);

        if (DescargaExistente == null)
        {
            return null;
        }
        
        //existingBascula.BasculaId = bascula.BasculaId;
        await _context.SaveChangesAsync();

        return descarga;
    }
    public async Task<Descarga> Create(Descarga descarga)
    {
        _context.Descargas.Add(descarga);
        await _context.SaveChangesAsync();

        return descarga;
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
