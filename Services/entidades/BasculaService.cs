
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class BasculaService
{
    private readonly MyContext _context;
    private readonly TipoEquipoServicio _tipoEServicio;
    private readonly EquipoServicio _equipoServicio;

    public BasculaService(MyContext context, TipoEquipoServicio tipoEServicio,EquipoServicio equipoServicio)
    {
        _context = context;
        _tipoEServicio=tipoEServicio;
        _equipoServicio=equipoServicio;
    }

    public async Task<Bascula> Get(int id)
    {
        var current_entity = await _context.Basculas.FindAsync(id);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }


    public async Task<IEnumerable<BasculaDto>> GetAll()
    {
        return await (from b in _context.Basculas
                          join s in _context.Sedes on b.NoSede equals s.SedeId
                          select new BasculaDto
                          {
                              BasculaId = b.BasculaId,
                              NoSerie = b.NoSerie,
                              NombreSede = s.NombreSede ?? string.Empty,
                              Descripcion = b.Descripcion
                          }).ToListAsync();
    }

    public async Task<IEnumerable<BasculaDto>> GetAll(int noSede)
    {
        return await (from b in _context.Basculas
                          join s in _context.Sedes on b.NoSede equals s.SedeId
                          where s.SedeId == noSede
                          select new BasculaDto
                          {
                              BasculaId = b.BasculaId,
                              NoSerie = b.NoSerie,
                              NombreSede = s.NombreSede ?? string.Empty,
                              Descripcion = b.Descripcion
                          }).ToListAsync();
    }

    

    public async Task<Bascula> Update(int id,Bascula bascula)
    {
        var existingBascula = await Get(id);

        if (existingBascula == null)
        {
            return null;
        }
        
        //existingBascula.BasculaId = bascula.BasculaId;
        await _context.SaveChangesAsync();

        return bascula;
    }

    public async Task<Bascula> Create(Bascula bascula,int NoSede)
    {
        if(_context.Basculas.Any(elemento => elemento.NoSerie == bascula.NoSerie))
            return null!;

        Bascula b1 = new Bascula();
        EquipoData e = new EquipoData();


        b1.NoSede = NoSede;
        b1.NoSerie = bascula.NoSerie;
        b1.BasculaId = bascula.BasculaId;
        b1.Descripcion = bascula.Descripcion;
        e.EquipoId = bascula.BasculaId;
        e.SedeId = bascula.NoSede;
        //falta ponerle el tipo de equipo
        if(await _context.TiposEquipos.AnyAsync(elemento => elemento.TipoE == "bascula")) 
        {
            e.TipoEId =  _context.TiposEquipos.First(elem => elem.TipoE == "bascula").TipoEId;
            await _equipoServicio.Create(e,NoSede); 
        }
        else{
           TipoEData tipoBascula=new TipoEData();
           tipoBascula.TipoE="bascula";
           tipoBascula.TipoEId=0;
           TipoEquipo TE = await _tipoEServicio.Create(tipoBascula);
           e.TipoEId=TE.TipoEId;
           await _equipoServicio.Create(e,NoSede);
           //cuando se borre esa bascula se debe borrar ese equipo
        }
           
        _context.Basculas.Add(b1);
        await _context.SaveChangesAsync();
        return b1;
    }

    public async Task Delete(int id)
    {
        var bascula = await Get(id);

        if (bascula == null)
        {
            return;
        }

        _context.Basculas.Remove(bascula);
        await _context.SaveChangesAsync();
    }
}
