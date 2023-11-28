using System.Text.Json.Serialization;
namespace ECOCEMProject;

public class TipoEquipo
{
    public int TipoEId { get; set; }
    public string? TipoE {get; set;}
    [JsonIgnore]
    public Equipo? Equipo {get; set;}
    [JsonIgnore]
    public List<MantenimientoNecesario> MantenimientosNecesarios {get;} = new();
}

