
using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class MantenimientoNecesario
{
    public int TipoEquipoId {get; set;}
    public int AMId {get; set;}
    public double HorasExpId {get; set; }

    [JsonIgnore]
    public List<HerramientaMantNecesario> HerramientaMantNecesarios {get; } = new();
}