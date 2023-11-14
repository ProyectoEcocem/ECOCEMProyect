using System.Collections.Generic;
using System;
namespace ECOCEMProyect;

public class Venta
{
    public int Id { get; set; }
    public int IdSede {get; set;}
    public int IdEntidadCompradora {get; set;}
    public DateTime IdFecha {get; set;}

    public required List<Carga> Cargas {get; set;}
}
