namespace ECOCEMProyect;

public class Equipo
{
    public int EquipoId {get; set;}
    public int SedeId {get; set;}
    public required Sede Sede {get; set;}

    public required TipoEquipo TipoEquipo {get; set;}
    public Brigada? Brigada {get;set;}

    //public List<RoturaEquipo> RoturasEquipos {get; set;}
    //public List<Reporte> Reportes {get; set;}
}