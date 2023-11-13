public class Equipo
{
    public int IdEquipo {get; set;}
    public int IdSede {get; set;}
    public Sede Sede {get; set;} = null!
    public List<RoturaEquipo> RoturasEquipos {get; set;}
}