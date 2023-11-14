using ECOCEMProyect;

namespace ECOCEMProyect;

public class AccionMantenimiento
{
    public int AMId { get; set; }
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
