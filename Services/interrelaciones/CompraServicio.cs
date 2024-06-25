using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ECOCEMProject;

public class CompraServicio
{
    private readonly MyContext _context;

    public CompraServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<Compra> Get(int SedeId,int FabricaId,DateTime FechaCompraId)
    {
        
        var current_entity = await _context.Compras.FindAsync( SedeId, FabricaId, FechaCompraId);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<CompraDto>> GetAll()
    {
        return await (from c in _context.Compras
                          join s in _context.Sedes on c.SedeId equals s.SedeId
                          join f in _context.Fabricas on c.FabricaId equals f.FabricaId
                          select new CompraDto
                          {
                              NombreSede = s.NombreSede ?? string.Empty,
                              NombreFabrica = f.Nombre ?? string.Empty,
                              FechaId = c.FechaId
                          }).ToListAsync();
    }

    public async Task<IEnumerable<CompraDto>> GetAll(int sedeId)
    {
        return await (from c in _context.Compras
                          join s in _context.Sedes on c.SedeId equals s.SedeId
                          join f in _context.Fabricas on c.FabricaId equals f.FabricaId
                          where c.SedeId == sedeId
                          select new CompraDto
                          {
                              NombreSede = s.NombreSede ?? string.Empty,
                              NombreFabrica = f.Nombre ?? string.Empty,
                              FechaId = c.FechaId
                          }).ToListAsync();
    }

    public async Task<Compra> Update(int SedeId,int FabricaId,DateTime FechaCompraId,Compra compra)
    {
        var CompraExistente = await Get(SedeId, FabricaId, FechaCompraId);

        if (CompraExistente == null)
        {
            return null!;
        }
        
       
        await _context.SaveChangesAsync();

        return compra;
    }
    public async Task<Compra> Create(CompraData compra, int NoSede)
    {
       if(_context.Compras.Any(elemento => elemento.SedeId == compra.SedeId && elemento.FabricaId== compra.FabricaId && elemento.FechaId==compra.FechaId))
            return null!;
            
        Compra f1 = new Compra();

        f1.SedeId = NoSede;
        f1.FabricaId = compra.FabricaId;
        f1.FechaId = compra.FechaId;

        _context.Compras.Add(f1);
        await _context.SaveChangesAsync();
        return f1;
    }
     public async Task Delete(int SedeId,int FabricaId,DateTime FechaCompraId)
    {
        var compra = await Get(SedeId, FabricaId, FechaCompraId);

        if (compra == null)
        {
            return;
        }

        _context.Compras.Remove(compra);
        await _context.SaveChangesAsync();
    }


}
