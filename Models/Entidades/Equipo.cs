using System.Text.Json.Serialization;
namespace ECOCEMProject;

public class Equipo
{
    public int EquipoId {get; set;}
    public int TipoEId { get; set; }
    public required TipoEquipo TipoEquipo {get; set;}
    //public int SedeId {get; set;}
    public required Sede Sede {get; set;}
    [JsonIgnore]
    public List<Reporte> Reportes = null!;

    //public List<RoturaEquipo> RoturasEquipos {get; set;}
    //public List<OrdenTrabajo> OrdenesTrabajo {get; } = new();
}