using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class MedicionSiloServicio
{
    private readonly MyContext _context;

    public MedicionSiloServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<MedicionSilo> Get(int SiloId,int MedidorId,DateTime FechaMId)
    {
       
        var current_entity = await _context.MedicionesSilos.FindAsync(SiloId,MedidorId,FechaMId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<MedicionSilo>> GetAll()
    {
        return await _context.MedicionesSilos.ToListAsync();
    }
    public async Task<MedicionSilo> Update(int SiloId,int MedidorId,DateTime FechaMId,MedicionSilo medicionSilo)
    {
        var medicionSiloExistente = await Get(SiloId,MedidorId,FechaMId);

        if (medicionSiloExistente == null)
        {
            return null!;
        }
        
        
        await _context.SaveChangesAsync();

        return medicionSilo;
    }
    public async Task<MedicionSilo> Create(MedicionSilo medicionSilo)
    {
        _context.MedicionesSilos.Add(medicionSilo);
        await _context.SaveChangesAsync();

        return medicionSilo;
    }
     public async Task Delete(int SiloId,int MedidorId,DateTime FechaMId)
    {
        var medicionSilo = await Get(SiloId,MedidorId,FechaMId);

        if (medicionSilo == null)
        {
            return;
        }

        _context.MedicionesSilos.Remove(medicionSilo);
        await _context.SaveChangesAsync();
    }


}
