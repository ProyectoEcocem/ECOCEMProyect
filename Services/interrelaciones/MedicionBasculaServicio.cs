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

    public async Task<List<MedicionBascula>> GetAll(int sedeId)
{
    var medicionesBascula = await _context.MedicionesBasculas
        .Join(_context.Basculas,
            mb => mb.BasculaId,
            b => b.BasculaId,
            (mb, b) => new { MedicionBascula = mb, Bascula = b })
        .Where(x => x.Bascula.NoSede == sedeId)
        .Select(x => x.MedicionBascula)
        .ToListAsync();

    return medicionesBascula;
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
    public async Task<MedicionBascula> Create(MedicionBasculaData medicionBascula)
    {
        
        MedicionBascula mb = new MedicionBascula();

        //creacion de medicion bascula
        mb.VehiculoId = medicionBascula.VehiculoId;
        mb.BasculaId = medicionBascula.BasculaId;
        mb.FechaBId = medicionBascula.FechaBId;
        mb.PesoB = medicionBascula.PesoB;


        _context.MedicionesBasculas.Add(mb);
        await _context.SaveChangesAsync();
        return mb;
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
