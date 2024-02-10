using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class MedicionBascula
{
    public int VehiculoId { get; set; }
    public int BasculaId { get; set; }
    public DateTime FechaBId {get; set;}

    public int PesoB {get; set; }

    public int TipoCementoId { get; set; }
    public int SiloId {get; set;}
    public DateTime FechaCargaId {get; set;}
    [JsonIgnore]
    public Carga? Carga {get; set; }

    
    [JsonIgnore]
    public Descarga? Descarga {get; set; }
}
