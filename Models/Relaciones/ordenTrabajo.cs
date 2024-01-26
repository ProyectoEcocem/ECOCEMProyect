
namespace ECOCEMProject;

using System.Text.Json.Serialization;
public class OrdenTrabajo
{
   public int EquipoId {get; set;} 
   public int BrigadaId {get; set;}
   public int TrabajadorId {get; set;}
   public DateTime FechaId {get; set;}

   [JsonIgnore]
   public required List<OrdenTrabajoRoturaEquipo>OrdenTrabajoRoturaEquipo{get;set;}
   [JsonIgnore]
   public List<AccionMantenimiento> AccionesMantenimiento {get; } = new(); 
   [JsonIgnore]
   public List<OrdenTrabajoAMRealizada> OrdenesAMRealizadas {get; } = new();
   [JsonIgnore]
   public List<OrdenTrabajoHerramienta> OrdenTrabajoHerramientas {get; } = new();
}