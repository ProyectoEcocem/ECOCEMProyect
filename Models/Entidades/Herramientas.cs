

using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Herramienta
{
    public int HerramientaId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion {get; set;}
    
    [JsonIgnore]
    public List<OrdenTrabajoHerramienta> OrdenTrabajoHerramientas {get; } = new();
    [JsonIgnore]
    public List<HerramientaMantNecesario> HerramientaMantNecesarios {get; } = new();
}