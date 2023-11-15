namespace ECOCEMProyect;

public class OrdenTrabajoRoturaEquipo
{
    public int EquipoId {get; set;} 
   public int BrigadaId {get; set;}
   public int TrabajadorId {get; set;}
   public DateTime FechaId {get; set;}
    public int RoturaId {get; set;}

    public required RoturaEquipo RoturaEquipo {get; set;} 
    public required OrdenTrabajo OrdenTrabajo {get; set;}


}
