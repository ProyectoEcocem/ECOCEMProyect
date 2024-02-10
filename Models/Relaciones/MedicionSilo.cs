using System.Text.Json.Serialization;
namespace ECOCEMProject;

public class MedicionSilo
{
    public int SiloId {get; set;}
    public int MedidorId { get; set; }
    public DateTime FechaMId {get; set;}

    public int Nivel {get; set; }
    public int PesoM {get; set; }
    public int Volumen {get; set; }


    //public int TipoCementoId { get; set; }
    //public int VehiculoId { get; set; }
    //public DateTime FechaCargaId {get; set;}
    [JsonIgnore]

    public Carga? Carga {get; set; }
    [JsonIgnore]
    public Descarga? Descarga {get; set; }

}
