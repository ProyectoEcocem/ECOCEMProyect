namespace ECOCEMProyect;

public class Descarga
{
    public int IdTipoCemento { get; set; }
    public int NoSilo {get; set;}
    public int IdVehiculo { get; set; }
    public DateTime Fecha {get; set;}

    //Laves de compra
    public int IdNoSede {get; set;}
    public int IdFabrica { get; set; }
    public DateTime IdFecha {get; set;}
    public Compra compra {get; set;}
}
