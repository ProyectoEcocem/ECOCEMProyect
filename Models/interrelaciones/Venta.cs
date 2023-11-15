using System.Collections.Generic;
using System;
namespace ECOCEMProyect;

public class Venta
{
    public int SedeId {get; set;}
    public int EntidadCompradoraId {get; set;}
    public DateTime FechaVentaId {get; set;}

    public required List<Carga> Cargas {get; set;}
}
