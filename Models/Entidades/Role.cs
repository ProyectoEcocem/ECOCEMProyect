using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Role: IdentityRole<int>
{
    public string RolNombre{get; set;}
    public string Descripcion{get; set; }

    [JsonIgnore]
    public required List<User> Users;

}
