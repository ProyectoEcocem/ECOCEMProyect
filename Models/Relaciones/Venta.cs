using System.Text.Json.Serialization;
namespace ECOCEMProject;

public class Venta
{
    public int SedeId {get; set;}
    public int EntidadCompradoraId {get; set;}
    public DateTime FechaVentaId {get; set;}

    [JsonIgnore]
    public List<Carga> Cargas {get; set;} = null!;
}
