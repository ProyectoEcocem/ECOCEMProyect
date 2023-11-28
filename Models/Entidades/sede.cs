using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Sede
{
    public int SedeId {get; set;}
    public string? NombreSede {get; set;}
    public string? UbicacionSede {get; set;}
    //public int EmpresaId {get; set;}
    //public  Empresa Empresa {get; set;} = null!;
    [JsonIgnore]
    public List<Trabajador>? Trabajadores {get;}
    
    public List<Equipo> Equipos {get;} = new();
}