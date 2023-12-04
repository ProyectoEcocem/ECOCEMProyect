using System.Text.Json.Serialization;
namespace ECOCEMProject;

public class TipoEquipo
{
    public int TipoEId { get; set; }
    public string TipoE {get; set;}

    
    public List<Equipo>? Equipos {get; }=new List<Equipo>();
    //[JsonIgnore]
    //public List<MantenimientoNecesario> MantenimientosNecesarios {get;} = new();
}

