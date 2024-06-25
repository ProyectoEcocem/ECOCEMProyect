using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ECOCEMProject;

public class UserRole : IdentityUserRole<int>
{
    [JsonIgnore]
    public int IdUser { get { return UserId; } set { UserId = value; } }
    [JsonIgnore]
    public int IdRole { get { return RoleId; } set { RoleId = value; } }

    [JsonIgnore]
    public User? User { get; set; }
    [JsonIgnore]
    public Role? Role { get; set; }
}
