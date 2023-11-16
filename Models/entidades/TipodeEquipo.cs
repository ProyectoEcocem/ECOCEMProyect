namespace ECOCEMProject.Models; 

public class TipoEquipo
{
    public int TipoEId { get; set; }
    public string TipoE {get; set;}
    public Equipo? Equipo {get; set;}

    public List<MantenimientoNecesario> MantenimientosNecesarios {get;} = new();
}

