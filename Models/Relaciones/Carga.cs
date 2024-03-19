using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Carga
{
    public int TipoCementoId { get; set; }
    public int SiloId {get; set;}
    public int VehiculoId { get; set; }
    public DateTime FechaCargaId {get; set;}

    public DateTime FechaFinal {get; set;}

    //llaves de venta
    public int SedeId {get; set;}
    public int EntidadCompradoraId {get; set;}
    public DateTime FechaVentaId {get; set;}
  
    [JsonIgnore]
    public Venta Venta {get; set; }

    [JsonIgnore]
    public ICollection<MedicionSilo> MedicionesSilo {get; set; }

    [JsonIgnore]
    public ICollection<MedicionBascula> MedicionesBascula {get; set; }
}
