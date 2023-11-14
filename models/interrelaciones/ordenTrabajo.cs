public class OrdenTrabajo
{
   public int EquipoId {get; set;} 
   public int BrigadaId {get; set;}
   public int TrabajadorId {get; set;}
   public DateTime FechaId {get; set;}

   public List<OrdenTrabajoAtendida> OrdenesTrabajoAtendidas {get;} = new();
}