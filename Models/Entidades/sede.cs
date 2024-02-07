using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Sede
{
    public int SedeId {get; set;}
    public string? NombreSede {get; set;}
    public string? UbicacionSede {get; set;}
    
    [JsonIgnore]
    public int EmpresaId {get; set;}
    
    [JsonIgnore]
    public virtual  Empresa Empresa {get; set;} = null!;
    //[JsonIgnore]
    public List<Trabajador>? Trabajadores {get;} = new List<Trabajador>();
    
    public List<Equipo> Equipos {get;} = new List<Equipo>();
}