using System.Text.Json.Serialization;
namespace ECOCEMProject;

public class RoturaEquipo
{
    public int EquipoId {get; set;}
    public int RoturaId {get; set;}
    public DateTime FechaId {get; set;}

    [JsonIgnore]
    public List<OrdenTrabajoRoturaEquipo>? OrdenTrabajoRoturaEquipo{get;set;}
}

