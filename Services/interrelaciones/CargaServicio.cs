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
    public async Task<Carga> Update(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId,Carga carga)
    {
        var CargaExistente = await Get(TipoCementoId,SiloId,VehiculoId,FechaCargaId);

        if (CargaExistente == null)
        {
            return null;
        }
        
        //existingBascula.BasculaId = bascula.BasculaId;
        await _context.SaveChangesAsync();

        return carga;
    }
    public async Task<Carga> Create(Carga carga)
    {
        _context.Cargas.Add(carga);
        await _context.SaveChangesAsync();

        return carga;
    }
     public async Task Delete(int TipoCementoId,int SiloId,int VehiculoId,DateTime FechaCargaId)
    {
        var carga = await Get(TipoCementoId,SiloId,VehiculoId,FechaCargaId);

        if (carga == null)
        {
            return;
        }

        _context.Cargas.Remove(carga);
        await _context.SaveChangesAsync();
    }


}
