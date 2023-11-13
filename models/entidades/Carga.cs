namespace ECOCEMProyect;

public class Carga
{
    public int IdTipoCemento { get; set; }
    public int IdNoSilo {get; set;}
    public int IdVehiculo { get; set; }
    public DateTime Fecha {get; set;}

    //Laves de venta
    public int IdNoSede {get; set;}
    public int IdEntidadCompradora {get; set;}
    public DateTime IdFecha {get; set;}
    public Venta venta {get; set; }
}
