using ECOCEMProyect;

namespace ECOCEMProyect;

public class RoturaEquipo
{
    public int EquipoId {get; set;}
    public int RoturaId {get; set;}
    public DateTime FechaId {get; set;}

    public required OrdenTrabajo OrdenTrabajo {get; set;}
}

