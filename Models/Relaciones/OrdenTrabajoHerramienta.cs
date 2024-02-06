
namespace ECOCEMProject;

public class OrdenTrabajoHerramienta
{
    public int HerramientasId {get; set; }
    public Herramienta? Herramientas {get; set;}
    
    //llaves de Orden de trabajo
    public int EquipoId {get; set;} 
    public int BrigadaId {get; set;}
    public int TrabajadorId {get; set;}
    public DateTime FechaId {get; set;}

    public OrdenTrabajo? OrdenTrabajo {get; set;}

    public string? UnidadMedidaU {get; set;}
    public int CantidadU {get; set;}
    public double Precio {get; set;}
    public string? ValeAlmacen {get; set;} 
    // TODO: Considerar crear un objeto ValeAlmacen con sus especificaciones. 
}