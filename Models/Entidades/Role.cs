using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Role: IdentityRole<int>
{
    //public string? Nombre { get { return Name; } set { Name = value; } }
    public string? Descripcion { get; set; }

    public List<User> Users { get; set; }
    
}