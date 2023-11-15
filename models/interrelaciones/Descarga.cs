using System.Collections.Generic;
namespace ECOCEMProyect;

public class Descarga
{
    public int TipoCementoId { get; set; }
    public int SiloId {get; set;}
    public int VehiculoId { get; set; }
    public DateTime FechaId {get; set;}

    public required Compra compra {get; set; }
    public required ICollection<MedicionSilo> MedicionesSilo {get; set; }
    public required ICollection<MedicionBascula> MedicionesBascula {get; set; }
}
