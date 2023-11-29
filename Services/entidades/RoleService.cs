using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace ECOCEMProject;

public class RoleService
{
    private readonly MyContext _context;
    private readonly RoleManager<Role> _roleManager;

    public RoleService(MyContext context,RoleManager<Role> roleManager)
    {
        _context = context;
        _roleManager = roleManager;
    }

    public async Task<Role> GetByName(string name)
    {
        var current_entity = await _roleManager.FindByNameAsync(name);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }

    public async Task<Role> Get(int id)
    {
        var current_entity = await _context.Roles.FindAsync(id);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }


    public async Task<IEnumerable<Role>> GetAll()
    {
        //var roles = await _context.Roles.Include(u=>u.Users).ToListAsync();
        return await _roleManager.Roles.ToListAsync();
        //return roles;
    }

    public  async Task Update(int id,string? role_name, RoleModel edited_role)
    {
        var current_role = await Get(id);
        current_role.Name = edited_role.Name;
        current_role.Descripcion = edited_role.Description;
        await _context.SaveChangesAsync();
        await _roleManager.UpdateAsync(current_role);
    }

    public async Task<Role> Create(RoleModel new_role)
        {
            if (await _roleManager.RoleExistsAsync(new_role.Name!))
                throw new InvalidOperationException("The role already exists");

            var role = new Role()
            {
                Name = new_role.Name,
                Descripcion = new_role.Description
            };

            /*var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
                throw new ArgumentException("Fatal error");
            */


           // _context.Roles.Add(role);
            //await _context.SaveChangesAsync();
            await _roleManager.CreateAsync(role);
            return role;
        }

    public async Task DeleteByName(string name)
    {
        var role = await GetByName(name);

        if (role == null)
        {
            return;
        }

        _context.Roles.Remove(role);
        await _roleManager.DeleteAsync(role);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        var role = await Get(id);

        if (role == null)
        {
            return;
        }

        _context.Roles.Remove(role);
        await _roleManager.DeleteAsync(role);
        await _context.SaveChangesAsync();
    }
}
