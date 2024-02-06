using System.Text.Json.Serialization;

namespace ECOCEMProject;

public class Silo
{
    public int SiloId {get; set;}
    public int EquipoId {get; set;}
    public string NoSilo {get; set;}
  
    [JsonIgnore]
    public Equipo Equipo {get;set;}
}
