using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ECOCEMProject;

public class UserRoleServicio
{
    private readonly MyContext _context;

    public UserRoleServicio(MyContext context)
    {
        _context = context;
    }
    public async Task<UserRole> Get(int idUser, int idRole)
    {
        
        var current_entity = await _context.UserRoles.FindAsync(idUser,idRole);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }
    public async Task<IEnumerable<UserRole>> GetAll()
    {
        return await _context.UserRoles.ToListAsync();
    }

    public async Task<UserRole> Create(int idUser, int idRole)
    {
        try
        {
            await Get(idUser, idRole);
            throw new InvalidOperationException("The relation already exists");
        }
        catch
        {
            var relation = new UserRole
            {
                UserId = idUser,
                RoleId = idRole,

            };
            _context.UserRoles.Add(relation);
            await _context.SaveChangesAsync();
            return relation;
        }
    }
     public async Task Delete(int idUser, int idRole)
    {
        var userRole = await Get(idUser,idRole);

        if (userRole == null)
        {
            return;
        }

        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync();
    }

}
