using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Sede
{
    public int SedeId {get; set;}
    public string? NombreSede {get; set;}
    public string? UbicacionSede {get; set;}
    public int EmpresaId {get; set;}
    public required Empresa Empresa {get; set;} 
    public required List<Trabajador> Trabajadores {get;set;} 
    public required List<Equipo> Equipos {get;set;}
}