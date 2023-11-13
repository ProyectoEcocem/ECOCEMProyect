using System.Collections.Generic;
namespace ECOCEMProyect;

public class Compra
{
    public int IdNoSede {get; set;}
    public int IdFabrica { get; set; }
    public DateTime IdFecha {get; set;}

    public List<Descarga> Descargas {get; set; }
}
