using ECOCEMProyect;

namespace ECOCEMProject.Models; 

public class OrdenTrabajoAMRealizada
{
    public int AMId {get; set;}
    public required AccionMantenimiento AccionMantenimiento {get; set;}

    //llaves de Orden de Trabajo
    public int EquipoId {get; set;} 
    public int BrigadaId {get; set;}
    public int TrabajadorId {get; set;}
    public DateTime FechaId {get; set;}

    public OrdenTrabajo? OrdenTrabajo {get; set;} 

    public string? Resultado {get ; set;} 
 
}