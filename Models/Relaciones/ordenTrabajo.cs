
namespace ECOCEMProject;

using System.Text.Json.Serialization;
public class OrdenTrabajo
{
   public int EquipoId {get; set;} 
   public int BrigadaId {get; set;}
   public int TrabajadorId {get; set;}
   public DateTime FechaId {get; set;}

   public required List<OrdenTrabajoRoturaEquipo>OrdenTrabajoRoturaEquipo{get;set;}

   public List<AccionMantenimiento> AccionesMantenimiento {get; } = new(); 

   public List<OrdenTrabajoAMRealizada> OrdenesAMRealizadas {get; } = new();
   public List<OrdenTrabajoHerramienta> OrdenTrabajoHerramientas {get; } = new();
}