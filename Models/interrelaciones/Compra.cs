using System.Collections.Generic;
namespace ECOCEMProject.Models; 

public class Compra
{
    public int SedeId {get; set;}
    public int FabricaId { get; set; }
    public DateTime FechaId {get; set;}

    public required ICollection<Descarga> Descargas {get; set; }
}
