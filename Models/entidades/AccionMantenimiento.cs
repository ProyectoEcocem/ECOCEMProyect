using ECOCEMProyect;

namespace ECOCEMProyect;

public class AccionMantenimiento
{
    public int AMId { get; set; }

    public int EquipoId {get; set;} 
    public int BrigadaId {get; set;}
    public int TrabajadorId {get; set;}
    public DateTime FechaId {get; set;}
    public List<OrdenTrabajo> OrdenesTrabajo {get; } = new();
    public List<OrdenTrabajoAMRealizada> OrdenesAMRealizadas {get; } = new();
}
public class MantenimientoImprevisto : AccionMantenimiento 
{
    
}
public class MantenimientoPlanificado : AccionMantenimiento 
{
    public List<MantenimientoNecesario> MantenimientosNecesarios {get;} = new();
}
