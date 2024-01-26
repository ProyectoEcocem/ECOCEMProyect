using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class HerramientaMantNecesarioServicio
{
    private readonly MyContext _context;

    public HerramientaMantNecesarioServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<HerramientaMantNecesario> Get(int HerramientasId,int TipoEquipoId,double HorasExpId)
    {
        //var current_entity = await _context.FindAsync<Bascula>(id);
        var current_entity = await _context.HerramientaMantNecesarios.FindAsync(HerramientasId,TipoEquipoId,HorasExpId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<HerramientaMantNecesario>> GetAll()
    {
        return await _context.HerramientaMantNecesarios.ToListAsync();
    }
    public async Task<HerramientaMantNecesario> Update(int HerramientasId,int TipoEquipoId,double HorasExpId,HerramientaMantNecesario herramientaMantNecesario)
    {
        var HerramientaMantNecesarioExistente = await Get(HerramientasId,TipoEquipoId,HorasExpId);

        if (HerramientaMantNecesarioExistente == null)
        {
            return null;
        }
        
        //existingBascula.BasculaId = bascula.BasculaId;
        await _context.SaveChangesAsync();

        return herramientaMantNecesario;
    }
    public async Task<HerramientaMantNecesario> Create(HerramientaMantNecesario herramientaMantNecesario)
    {
        _context.HerramientaMantNecesarios.Add(herramientaMantNecesario);
        await _context.SaveChangesAsync();

        return herramientaMantNecesario;
    }
     public async Task Delete(int HerramientasId,int TipoEquipoId,double HorasExpId)
    {
        var herramientaMantNecesario = await Get(HerramientasId,TipoEquipoId,HorasExpId);

        if (herramientaMantNecesario == null)
        {
            return;
        }

        _context.HerramientaMantNecesarios.Remove(herramientaMantNecesario);
        await _context.SaveChangesAsync();
    }


}
