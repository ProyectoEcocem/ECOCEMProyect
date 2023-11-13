using System.Collections.Generic;
using System;
namespace ECOCEMProyect;

public class Venta
{
    public int IdNoSede {get; set;}
    public int IdEntidadCompradora {get; set;}
    public DateTime IdFecha {get; set;}

    public List<Carga> Cargas {get; set;}
}
