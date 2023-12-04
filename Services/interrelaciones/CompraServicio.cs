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
    public async Task<IEnumerable<Compra>> GetAll()
    {
        return await _context.Compras.ToListAsync();
    }
    public async Task<Compra> Update(int SedeId,int FabricaId,DateTime FechaCompraId,Compra compra)
    {
        var CompraExistente = await Get(SedeId, FabricaId, FechaCompraId);

        if (CompraExistente == null)
        {
            return null;
        }
        
       
        await _context.SaveChangesAsync();

        return compra;
    }
    public async Task<Compra> Create(Compra compra)
    {
        _context.Compras.Add(compra);
        await _context.SaveChangesAsync();

        return compra;
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
