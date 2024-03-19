using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Descarga
{
    public int TipoCementoId { get; set; }
    public int SiloId {get; set;}
    public int VehiculoId { get; set; }
    public DateTime FechaId {get; set;}

    //llaves foraneas de compra
    public int SedeId {get; set;}
    public int FabricaId { get; set; }
    public DateTime FechaCompraId {get; set;}

    [JsonIgnore]
    public  Compra Compra {get; set; }
    [JsonIgnore]
    public  ICollection<MedicionSilo> MedicionesSilo {get; set; }
    [JsonIgnore]
    public  ICollection<MedicionBascula> MedicionesBascula {get; set; }
}
