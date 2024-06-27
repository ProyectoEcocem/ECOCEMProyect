using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Descarga
{
    public int DescargaId { get; set; }
    public int TipoCementoId { get; set; }
    public int SiloId {get; set;}
    public int VehiculoId { get; set; }
    public DateTime FechaId {get; set;}

    //otras propiedades de descarga
    public int PesoBruto {get; set;}
    public int Tara {get; set;}
    public int Temperatura {get; set;}
    public int TipoAsentamiento {get; set;}
    public int Corriente {get; set;}

    public int PesoNeto {
        get{ return PesoBruto - Tara; }
    }
    public int PesoCalculado {
        get{ return 0; }
    }
    public int PesoLimpManual {
        get{ return 0; }
    }

    //llaves foraneas de compra
    public int SedeId {get; set;}
    public int FabricaId { get; set; }
    public DateTime FechaCompraId {get; set;}

    [JsonIgnore]
    public  Compra? Compra {get; set; }
    [JsonIgnore]
    public  ICollection<MedicionSilo>? MedicionesSilo {get; set; }
    [JsonIgnore]
    public  ICollection<MedicionBascula>? MedicionesBascula {get; set; }
}
