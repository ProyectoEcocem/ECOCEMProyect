using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class AccionMantenimiento
{
    public int AMId { get; set; }
    public string Descripcion { get; set; }

    [JsonIgnore]
    public List<OrdenTrabajo> OrdenesTrabajo {get; } = new();
    [JsonIgnore]
    public List<OrdenTrabajoAMRealizada> OrdenesAMRealizadas {get; } = new();
}

public class MantenimientoImprevisto : AccionMantenimiento 
{
    
}
public class MantenimientoPlanificado : AccionMantenimiento 
{
    [JsonIgnore]
    public List<MantenimientoNecesario> MantenimientosNecesarios {get;} = new();
}
