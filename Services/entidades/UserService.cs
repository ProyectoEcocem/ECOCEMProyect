using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ECOCEMProject;

public class UserService
{
    private readonly MyContext _context;
   

    public UserService(MyContext context)
    {
        _context = context;
    }

    public async Task<User> GetByName(string name)
    {
        var current_entity = await _context.Users.FirstAsync(x => 
        x.UserName == name
        );
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }

    public async Task<User> Get(int id)
    {
        var current_entity = await _context.Users.FindAsync(id);
        
        if(current_entity == null!){
             throw new InvalidOperationException("Entidad no encontrada");
        }
        return current_entity;
    }


    public async Task<IEnumerable<User>> GetAll()
    {
       
        var roles = _context.Users.Include(e => e.Roles).ToList();
        return roles;

    }

    /*public async Task Update(int user_id, [FromBody]RegistrationModel edited_model)
        {
            var current_user = await Get(user_id);
            current_user.UserName = edited_model.Name;

            if (edited_model.Old_Password is not null && edited_model.Password is not null)
                await _context.ChangePasswordAsync(
                    current_user, edited_model.Old_Password, edited_model.Password
                );


            await _context.UpdateAsync(current_user);
        }*/

    public  async Task<User> Create(RegistrationModel new_user)
    {
        if (await _context.Users.FirstAsync(x => x.UserName == new_user.Name) is not null)
            throw new InvalidOperationException("The user already exists");

        var user = new User()
        {
            UserName = new_user.Name,
            Email = new_user.Email
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    
        return user;
    }

    public async Task DeleteByName(string name)
    {
        var user = await GetByName(name);

        if (user == null)
        {
            return;
        }

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        var user = await Get(id);

        if (user == null)
        {
            return;
        }

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}
