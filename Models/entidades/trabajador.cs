namespace ECOCEMProject.Models; 

public class Trabajador
{
    public int TrabajadorId {get; set;}
    public string NombreTrabajador {get; set;}
    public required Sede Sede {get; set;}

    public List<OrdenTrabajoAtendida> OrdenesTrabajoAtendidas {get;} = new();
}