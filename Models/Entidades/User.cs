using Microsoft.AspNetCore.Identity;

namespace ECOCEMProject;

public class User 
{
    public int UserId { get; set; }
    public string UserName { get; set; }

    public string? Email { get; set; }
    public List<Role> Roles {get; } = new();

}
