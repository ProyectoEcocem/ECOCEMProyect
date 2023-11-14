namespace ECOCEMProyect;

public class Trabajador
{
    public int IdTrabajador {get; set;}
    public string NombreTrabajador {get; set;}
    public required Sede Sede {get; set;}
}