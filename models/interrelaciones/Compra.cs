using System.Collections.Generic;
namespace ECOCEMProyect;

public class Compra
{
    public int Id { get; set; }
    public int SedeId {get; set;}
    public int FabricaId { get; set; }
    public DateTime FechaId {get; set;}

    public required ICollection<Descarga> Descargas {get; set; }
}
