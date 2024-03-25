using Microsoft.AspNetCore.Identity;

namespace ECOCEMProject;

public class User : IdentityUser<int>
{
    public string? Nombre { get { return UserName; } set { UserName = value; } }
    public int NoSede { get; set; }
    public List<Role> Roles {get; } = new();

}
