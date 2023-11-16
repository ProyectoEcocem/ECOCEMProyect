
namespace ECOCEMProyect;

public class OrdenTrabajo
{
   public int EquipoId {get; set;} 
   public int BrigadaId {get; set;}
   public int TrabajadorId {get; set;}
   public DateTime FechaId {get; set;}


   //public int EquipoREId {get{return EquipoId;}  set {EquipoREId = value;}} 
    /*public int RoturaId {get; set;}
    //public DateTime FechaREId {get{return FechaId;}  set {FechaREId=value;}} 
   public required RoturaEquipo RoturaEquipo {get; set;} */

   public required List<OrdenTrabajoRoturaEquipo>OrdenTrabajoRoturaEquipo{get;set;}

   public List<AccionMantenimiento> AccionesMantenimiento {get; } = new(); 

   public List<OrdenTrabajoAMRealizada> OrdenesAMRealizadas {get; } = new();
   public List<OrdenTrabajoHerramienta> OrdenTrabajoHerramientas {get; } = new();
}