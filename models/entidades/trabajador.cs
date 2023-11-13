public class Trabajador
{
    public int IdTrabajador {get; set;}
    public string NombreTrabajador {get; set;}
    public int IdSede {get; set;}
    public Sede Sede {get; set;} = null!
}