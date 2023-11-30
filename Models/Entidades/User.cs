using Microsoft.AspNetCore.Identity;

namespace ECOCEMProject;

public class User : IdentityUser<int>
{

    public List<Role>? Roles {get;set;}
}
