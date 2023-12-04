using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }

    public string? Descripcion { get; set; }

    public List<User> Users { get; } = new();

    
}