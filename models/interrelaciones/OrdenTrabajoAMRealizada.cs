using ECOCEMProyect;

namespace ECOCEMProyect;

public class OrdenTrabajoAMRealizada
{
    public int AMId {get; set;}

    //llaves de Orden de Trabajo
    public int EquipoId {get; set;} 
    public int BrigadaId {get; set;}
    public int TrabajadorId {get; set;}
    public DateTime FechaId {get; set;}

    public required AccionMantenimiento AccionMantenimiento {get; set;}
    public OrdenTrabajo OrdenTrabajo {get; set;} //no requerido necesariamente.

    public string Resultado {get ; set;} 
    // Question: Que es resultado?
}