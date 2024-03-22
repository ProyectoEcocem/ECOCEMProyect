using Microsoft.EntityFrameworkCore;

namespace ECOCEMProject;

public class SiloServicio
{
    private readonly MyContext _context;
    private readonly TipoEquipoServicio _tipoEServicio;
    private readonly EquipoServicio _equipoServicio;

    public SiloServicio(MyContext context, TipoEquipoServicio tipoEServicio,EquipoServicio equipoServicio)
    {
        _context = context;
        _tipoEServicio=tipoEServicio;
        _equipoServicio=equipoServicio;
    }

    public async Task<Silo> Get(int id)
    {
        var current_entity = await _context.Silos.FindAsync(id);
        if (current_entity == null)
        {
            return null;
        }
        return current_entity;
    }

    public async Task<IEnumerable<Silo>> GetAll()
    {
        return await _context.Silos.ToListAsync();
    }

    public async Task<IEnumerable<Silo>> GetAll(int sedeId)
    {
        return await _context.Silos.Where(s => s.NoSede == sedeId).ToListAsync();
    }

    public async Task<Silo> Update(int id, Silo silo)
    {
        var siloExistente = await Get(id);
        if (siloExistente == null)
        {
            return null;
        }
        //siloExistente.EquipoId = silo.EquipoId;
        await _context.SaveChangesAsync();
        return silo;
    }

    public async Task<Silo> Create(SiloData silo)
    {
       if(_context.Silos.Any(elemento => elemento.NoSilo == silo.NoSilo))
            return null!;

        Silo s1 = new Silo();
        EquipoData e = new EquipoData();
        s1.altura=silo.altura;
        s1.NoSede=silo.NoSede;
        s1.radio=silo.radio;
        s1.SiloId=silo.SiloId;
        s1.NoSilo=silo.NoSilo;

        e.EquipoId = silo.SiloId;
        e.SedeId = silo.NoSede;
        //falta ponerle el tipo de equipo
        if(await _context.TiposEquipos.AnyAsync(elemento => elemento.TipoE == "silo")) 
        {
            e.TipoEId =  _context.TiposEquipos.First(elem => elem.TipoE == "silo").TipoEId;
            await _equipoServicio.Create(e); 
        }
        else{
           TipoEData tipoSilo=new TipoEData();
           tipoSilo.TipoE="silo";
           tipoSilo.TipoEId=0;
           TipoEquipo TE = await _tipoEServicio.Create(tipoSilo);
           e.TipoEId=TE.TipoEId;
           await _equipoServicio.Create(e);
           //cuando se borre ese silo se debe borrar ese equipo
        }
           
        _context.Silos.Add(s1);
        await _context.SaveChangesAsync();
        return s1;
    }

    public async Task Delete(int id)
    {
        var silo = await Get(id);
        if (silo == null)
        {
            return;
        }
        _context.Silos.Remove(silo);
        await _context.SaveChangesAsync();
    }
}
