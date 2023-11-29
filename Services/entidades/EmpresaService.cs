using Microsoft.EntityFrameworkCore;

namespace ECOCEMProject;

public class EmpresaService
{
    private readonly MyContext _context;

    public EmpresaService(MyContext context)
    {
        _context = context;
    }

    public async Task<Empresa> Get(int id)
    {
        var current_entity = await _context.Empresas.FindAsync(id);
        if (current_entity == null)
        {
            return null;
        }
        return current_entity;
    }

    public async Task<IEnumerable<Empresa>> GetAll()
    {
        var empresas=_context.Empresas.Include(e => e.Sedes).ThenInclude(e=>e.Trabajadores).ToList();
        return empresas;
    }

    public async Task<Empresa> Update(int id, Empresa empresa)
    {
        var existenteEmpresa = await Get(id);
        if (existenteEmpresa == null)
        {
            return null;
        }
        existenteEmpresa.EmpresaId = empresa.EmpresaId;
        await _context.SaveChangesAsync();
        return empresa;
    }

    public async Task<Empresa> Create(Empresa empresa)
    {
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();
        return empresa;
    }

    public async Task Delete(int id)
    {
        var empresa= await Get(id);
        if (empresa == null)
        {
            return;
        }
        _context.Empresas.Remove(empresa);
        await _context.SaveChangesAsync();
    }
}
