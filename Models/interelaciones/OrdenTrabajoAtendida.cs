namespace ECOCEMProject;

public class OrdenTrabajoAtendida
{
    public int TrabajadorId {get; set;}
    public DateTime DiaId {get; set;}

    //llaves de Orden de Trabajo
    // Question:Se define así?
    public int EquipoId {get; set;} 
    public int BrigadaId {get; set;}
    //public int TrabajadorId {get; set;}
    public DateTime FechaId {get; set;}
    public OrdenTrabajo? OrdenTrabajo {get; set;}

    public double PrecioPorHora {get; set;}
    public double NoHoras {get; set;}

    // TODO: tener en cuenta en un futuro método para calcular el precio total.
}