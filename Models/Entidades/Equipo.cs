using System.Text.Json.Serialization;
namespace ECOCEMProject;

public class Equipo
{
    public int EquipoId {get; set;}
    public int TipoEId { get; set; }
    public TipoEquipo TipoEquipo {get; set;}
    public int SedeId {get; set;}
    [JsonIgnore]
    public  Sede Sede {get; set;}
    
    //public List<Reporte> Reportes = null!;

    //public List<RoturaEquipo> RoturasEquipos {get; set;}
    //public List<OrdenTrabajo> OrdenesTrabajo {get; } = new();
}