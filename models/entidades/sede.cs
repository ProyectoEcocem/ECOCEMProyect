namespace ECOCEMProyect;

public class Sede
{
    public int IdSede {get; set;}
    public string NombreSede {get; set;}
    public string UbicacionSede {get; set;}
    public int IdEmpresa {get; set;}
    public required Empresa Empresa {get; set;} 
    public required List<Trabajador> Trabajadores {get;set;} 
    public required List<Equipo> Equipos {get;set;}
}