
using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Compra
{
    public int SedeId {get; set;}
    public int FabricaId { get; set; }
    public DateTime FechaId {get; set;}

    
    [JsonIgnore]
    public  ICollection<Descarga> Descargas {get; set; } = null!;
}
