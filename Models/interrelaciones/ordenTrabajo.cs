using ECOCEMProyect;

namespace ECOCEMProyect;

public class OrdenTrabajo
{
   public int EquipoId {get; set;} 
   public int BrigadaId {get; set;}
   public int TrabajadorId {get; set;}
   public DateTime FechaId {get; set;}

   /*public int RoturaId {get; set;}
   public required RoturaEquipo RoturaEquipo {get; set;} */

   public required List<OrdenTrabajoRoturaEquipo>OrdenTrabajoRoturaEquipo{get;set;}

   public List<AccionMantenimiento> AccionesMantenimiento {get; } = new(); 
   // Question: es necesario el mod 'required'?

   public List<OrdenTrabajoAMRealizada> OrdenesAMRealizadas {get; } = new();
   public List<OrdenTrabajoHerramienta> OrdenTrabajoHerramientas {get; } = new();
}