
namespace ECOCEMProject;

public class OrdenTrabajoAMRealizada
{
    public int AMId {get; set;}
    public AccionMantenimiento? AccionMantenimiento {get; set;}

    //llaves de Orden de Trabajo 
    public int EquipoId {get; set;} 
    public int BrigadaId {get; set;}
    public int TrabajadorId {get; set;}
    public DateTime FechaId {get; set;}

    public OrdenTrabajo OrdenTrabajo {get; } = null!;

    public string Resultado {get ; set;} = null!;
 
}