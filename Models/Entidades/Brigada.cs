using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Brigada
{
    public int BrigadaId { get; set; }
    public string? Descripcion { get; set; }
    
    [JsonIgnore]
    public List<OrdenTrabajo> OrdenesTrabajo {get; } = new();
}