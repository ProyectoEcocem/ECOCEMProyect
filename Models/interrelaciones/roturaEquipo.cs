using ECOCEMProyect;

namespace ECOCEMProyect;

public class RoturaEquipo
{
    public int EquipoId {get; set;}
    public int RoturaId {get; set;}
    public DateTime FechaId {get; set;}

   /* public int TrabajadorId {get; set;}
    public int BrigadaId {get; set;}
    public required OrdenTrabajo OrdenTrabajo {get; set;}*/
    public required List<OrdenTrabajoRoturaEquipo>OrdenTrabajoRoturaEquipo{get;set;}
}

