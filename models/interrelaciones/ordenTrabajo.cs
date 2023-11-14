using ECOCEMProyect;

namespace ECOCEMProyect;

public class OrdenTrabajo
{
   public int EquipoId {get; set;} 
   public int BrigadaId {get; set;}
   public int TrabajadorId {get; set;}
   public DateTime FechaId {get; set;}

   public List<OrdenTrabajoAtendida> OrdenesTrabajoAtendidas {get;} = new();
   public RoturaEquipo? RoturaEquipo {get; set;} // Question: en realidad es 1,1 o 0,1?

   // Question: Debo poner las llaves de RoturaEquipo?

   public List<AccionMantenimiento> AccionesMantenimiento {get; } = new(); 
   // Question: es necesario el mod 'required'?
}