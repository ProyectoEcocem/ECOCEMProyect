using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class MedicionBasculaServicio
{
    private readonly MyContext _context;

    public MedicionBasculaServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<MedicionBascula> Get(int BasculaId,int VehiculoId,DateTime FechaBId)
    {
        //var current_entity = await _context.FindAsync<Bascula>(id);
        var current_entity = await _context.MedicionesBasculas.FindAsync(BasculaId,VehiculoId,FechaBId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<MedicionBascula>> GetAll()
    {
        return await _context.MedicionesBasculas.ToListAsync();
    }
    public async Task<MedicionBascula> Update(int BasculaId,int VehiculoId,DateTime FechaBId,MedicionBascula medicionBascula)
    {
        var medicionBasculaExistente = await Get(BasculaId,VehiculoId,FechaBId);

        if (medicionBasculaExistente == null)
        {
            return null!;
        }
        
        await _context.SaveChangesAsync();

        return medicionBascula;
    }
    public async Task<MedicionBascula> Create(MedicionBascula medicionBascula)
    {
        _context.MedicionesBasculas.Add(medicionBascula);
        await _context.SaveChangesAsync();

        return medicionBascula;
    }
     public async Task Delete(int BasculaId,int VehiculoId,DateTime FechaBId)
    {
        var medicionBascula = await Get(BasculaId,VehiculoId,FechaBId);

        if (medicionBascula == null)
        {
            return;
        }

        _context.MedicionesBasculas.Remove(medicionBascula);
        await _context.SaveChangesAsync();
    }


}
